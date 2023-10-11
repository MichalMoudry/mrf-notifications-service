namespace NotificationsService.Database.Model.Dto;

public sealed record PublicNotificationData(
    Guid Id,
    string Title,
    string Content,
    NotificationType Type,
    string UserId
);