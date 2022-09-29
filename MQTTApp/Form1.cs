using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPRabbitMQ;

namespace MQTTApp
{
    public partial class Form1 : Form
    {
        public AMPQ client { get; set; }
        private string _msg;
        public event EventHandler NewMessage;
        protected virtual void OnNewMessage(string message)
        {
            if(NewMessage != null) NewMessage(this, EventArgs.Empty);

            lbChatCanvas.Invoke((MethodInvoker)(() => 
            lbChatCanvas.Items.Add($"[{DateTime.Now.ToString()}]: said: {message}")
            ));


        }
        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                OnNewMessage(_msg);
            }
        }
        public Form1()
        {
            InitializeComponent();
            //Msg += new EventHandler(OnNewMessage);
        }

        private void OnNewMessage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //var exchangeType = cbExchangeType.SelectedItem.ToString();
            var message = txtMessage.Text;
            var routingKey = cbContacts.SelectedItem.ToString();
            var exchangeType = "Topic";
            SendMessage(exchangeType, "chat", routingKey, message);
        }
        private void SendMessage(string exchangeType, string exchangeName, string routingKey, string message)
        {        
            if (exchangeType == "Topic")
                client.CreateModelTopic(exchangeName);
            else if (exchangeType == "Fanout")
                client.CreateModelFanout(exchangeName);
            else
                return;

            client.PublishToExchange(exchangeName, routingKey, message);
            lbChatCanvas.Items.Add($"[{DateTime.Now.ToString()}]: {txtUser.Text} said: {message}");
            txtMessage.Clear();
        }

        private void txtUser_Validated(object sender, EventArgs e)
        {
        }

        private void messageArrived(object sender, EventArgs e)
        {
            lbChatCanvas.Items.Add($"[{DateTime.Now.ToString()}]: said: {client.receivedMessage}");
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new AMPQ();
            client.Connection(txtServerName.Text);
            client.CreateModelTopic("chat");
            string[] routingKeys = { "All", txtUser.Text };

            CreateConsumer(client.channel, "chat", "", routingKeys);
            //client.receivedMessage += new EventHandler(messageArrived);
            txtMessage.Visible = true;
            btnSend.Visible = true;
            lbChatCanvas.Visible = true;

        }

        public void CreateConsumer(IModel channel, string exchangeName, string queueName, string[] routingKeys)
        {
            if (queueName == null || queueName == "")
            {
                queueName = channel.QueueDeclare().QueueName;
            }

            foreach (var bindingKey in routingKeys)
            {
                channel.QueueBind(
                    queue: queueName,
                    exchange: exchangeName,
                    routingKey: bindingKey
                    );
            }

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                Msg = Encoding.UTF8.GetString(body);
                //lbChatCanvas.Items.Add($"[{DateTime.Now.ToString()}]: said: {receivedMessage}");

            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }
    }
}
