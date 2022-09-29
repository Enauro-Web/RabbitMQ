using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TPRabbitMQ;

namespace RabbitMQ.Publisher
{
    internal class Send
    {
        static void Main(string[] args)
        {

            string exchangeName = "topic_logs";
            string routingKey = "Pajaro";
            string message = "Este es un mensaje para los pajaros solo";

            var client = new AMPQ();
            client.Connection("localhost");
            client.CreateModelTopic(exchangeName);

            client.PublishToExchange(exchangeName, routingKey, message);

            /*

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                   

                    channel.ExchangeDeclare(
                        exchange:"topic_logs",
                        type: ExchangeType.Topic
                        );

                    var routingKey = (args.Length > 0) ? args[0] : "anonimous.info";

                    string message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "topic_logs",
                        routingKey: routingKey,
                        basicProperties: null,
                        body: body
                        );
                    Console.WriteLine($"[x] Sent: {message}. Routing key: {routingKey}");
                }
            }
            */
            Console.WriteLine("Press any key to exit ...");
            Console.ReadLine();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 1) ? string.Join(" ", args.Skip(1).ToArray()) : "info Hello World");
        }
    }
}
