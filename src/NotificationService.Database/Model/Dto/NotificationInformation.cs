using NotificationService.Database.Model.Domain;

namespace NotificationService.Database.Model.Dto;

public sealed class NotificationInformation
{
    public Guid Id { get; init; }

    public string? ContentKey { get; init; }

    public NotificationType Type { get; init; }

    public DateTime DateAdded { get; init; }
}