


using FluentValidation.Results;
using ThundersChallenge.Domain.Common;

namespace ThundersChallenge.Application.Notification;

public class NotificationContext
{
    private readonly List<BaseNotification> _notifications;
    public IReadOnlyCollection<BaseNotification> Notifications => _notifications;
    public bool HasNotifications => _notifications.Any();

    public NotificationContext()
    {
        _notifications = [];
    }

    public void AddNotification(string key, string message)
    {
        _notifications.Add(new BaseNotification(key, message));
    }

    public void AddNotification(BaseNotification notification)
    {
        _notifications.Add(notification);
    }

    public void AddNotifications(IEnumerable<BaseNotification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(IReadOnlyCollection<BaseNotification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(IList<BaseNotification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ICollection<BaseNotification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddNotification(error.ErrorCode, error.ErrorMessage);
        }
    }
}
