namespace NotificationsService.Service.Model.Dto;

public sealed class NotificationDto
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public NotificationType Type { get; set; }

    public DateTime DateAdded { get; set; }
}