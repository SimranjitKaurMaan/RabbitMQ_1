using System;
using System.Text;
using RabbitMQ.Client;

namespace Send
{
    class Program
    {
      public  static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "course.hello",
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

                    string message = "Hello World2!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "course.hello",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
        }
    }
}
