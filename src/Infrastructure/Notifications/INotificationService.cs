namespace Infrastructure.Notifications;

public interface INotificationService
{
    void SendNotification(string message);
}