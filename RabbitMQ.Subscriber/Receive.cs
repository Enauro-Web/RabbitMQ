using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Subscriber
{
    internal class Receive
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    /*channel.QueueDeclare(
                        queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );*/

                    channel.ExchangeDeclare(
                        exchange: "chat",
                        type: ExchangeType.Topic
                        );

                    var queueName = channel.QueueDeclare().QueueName;
                    Console.WriteLine($"Selected Queue .... {queueName}");

                    if(args.Length < 1)
                    {
                        Console.Error.WriteLine("USUARIO: {0} [binding_key...]",Environment.GetCommandLineArgs()[0]);
                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                        Environment.ExitCode = 1;
                        return;
                    } 

                    foreach(var bindingKey in args)
                    {
                        channel.QueueBind(
                            queue: queueName, 
                            exchange: "chat", 
                            routingKey: bindingKey
                            );
                    }                    

                    Console.WriteLine("Waiting for Logs ....");

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"[x] Received: {message}");
                    };

                    channel.BasicConsume(queue: queueName, autoAck:true, consumer: consumer);
                    Console.WriteLine("Press any key to exit ...");
                    Console.ReadLine();
                }
            }
           
        }
    }
}
