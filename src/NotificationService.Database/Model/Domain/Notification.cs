namespace NotificationService.Database.Model.Domain;

public sealed class Notification : Entity
{
    public string? ContentKey { get; init; }

    public NotificationType Type { get; init; }

    public string? UserId { get; init; }

    public bool IsDeleted { get; init; }
}