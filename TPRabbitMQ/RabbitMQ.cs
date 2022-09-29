using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRabbitMQ
{
    public class AMPQ
    {
        public ConnectionFactory factory { get; set; }
        public IConnection connection { get; set; }
        public IModel channel { get; set; }
        private string _receivedMessage;
        public string receivedMessage
        {
            get { return _receivedMessage; }
            set
            { 
                _receivedMessage = value;
                OnMessageArrived();
            }
        }
        public event EventHandler MessageArrived;

        public IConnection Connection(string RabbitMQServer)
        {
            factory = new ConnectionFactory()
            {
                HostName = RabbitMQServer
            };

            connection = factory.CreateConnection();

            return connection;

        }

        public IModel CreateModelTopic(string exchangeName)
        {
            channel = connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: exchangeName,
                type: ExchangeType.Topic
                );

            return channel;
        }

        public IModel CreateModelFanout(string exchangeName)
        {
            channel = connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: exchangeName,
                type: ExchangeType.Fanout
                );

            return channel;
        }

        public void PublishToExchange(string exchangeName, string routingKey, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                exchange: exchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: body
            );

        }  
        
        public void CreateConsumer(IModel channel, string exchangeName, string queueName, string[] routingKeys)
        {
            if(queueName == null || queueName == "")
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
                _receivedMessage = Encoding.UTF8.GetString(body);
                
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        } 

        protected virtual void OnMessageArrived()
        {
            EventHandler handler = MessageArrived;
            if(handler != null) handler(this, EventArgs.Empty);
        }

    }
}
