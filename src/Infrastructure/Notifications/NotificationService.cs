using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Infrastructure.Notifications;

public class NotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };

        var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();
        channel.QueueDeclare("notification", false, false, false, null);

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish("", "notification", null, body);
    }
}