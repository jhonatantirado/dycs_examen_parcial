using System;
using RabbitMQ.Client;
using System.Text;

namespace EnterprisePatterns.Api.Common.Application
{
    public class KipubitRabbitMQ
    {
        public static void SendMessage(string message)
        {
            var factory = new ConnectionFactory();
            string rabbitmqUrl = Environment.GetEnvironmentVariable("KipubitMQ_URL");
            factory.Uri = new Uri(rabbitmqUrl);
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "events", durable: true, exclusive: false, autoDelete: false, arguments: null);           
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "events", basicProperties: null, body: body);
            }
        }
    }
}
