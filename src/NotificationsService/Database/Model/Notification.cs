namespace NotificationsService.Database.Model;

/// <summary>
/// An entity representing a notification.
/// </summary>
public sealed record Notification(
    Guid Id,
    string Title,
    string Content,
    NotificationType Type,
    string UserId,
    bool IsDeleted,
    DateTime DateAdded,
    DateTime DateUpdated
);