using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace DenemeRabbitMq.subscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://hyxingls:GFLXFn53VOopBo0rDk67ZkPHfdajt2qK@toucan.lmq.cloudamqp.com/hyxingls");

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

           // bu satırı yazmak zorunda değilsin eğer yazarsan subscriber bu kuyruğu oluşturmazsa bu otomatik oluşturur
           // channel.QueueDeclare("hello-queue", durable: true, exclusive: false, autoDelete: false);

            var consumer= new EventingBasicConsumer(channel);
            
            channel.BasicConsume("hello-queue", autoAck: true, consumer);
            
            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var body = e.Body.ToArray();
                var message = System.Text.Encoding.UTF8.GetString(body);
                Console.WriteLine($"Mesaj Alındı: {message}");
            };

            Console.ReadLine();
        }
    }
}
