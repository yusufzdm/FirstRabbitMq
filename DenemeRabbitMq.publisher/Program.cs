using RabbitMQ.Client;
using System;

namespace DenemeRabbitMq.publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://hyxingls:GFLXFn53VOopBo0rDk67ZkPHfdajt2qK@toucan.lmq.cloudamqp.com/hyxingls");

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("hello-queue", durable: true, exclusive: false, autoDelete: false);

            string message = "Hello World!";
            var messagebody = System.Text.Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty, "hello-queue", null, messagebody);
            Console.WriteLine($"Mesaj Gönderildi: {message}");
            Console.ReadLine();
        }
    }
}
