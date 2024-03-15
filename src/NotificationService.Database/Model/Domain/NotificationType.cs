namespace NotificationService.Database.Model.Domain;

/// <summary>
/// An enumeration for representing a type of a notification.
/// </summary>
public enum NotificationType
{
    Positive = 0,
    Negative = 1,
    Warning = 2,
    Info = 3
}