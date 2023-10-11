using MediatR;

namespace NotificationsService.Service.Api.Handlers;

/// <summary>
/// Command for marking a notification as deleted (but not completely deleted from the database).
/// </summary>
public sealed record MarkDeletedNotifCommand(Guid notificationId) : IRequest<bool>;