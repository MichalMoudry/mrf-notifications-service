using MediatR;
using NotificationsService.Service.Model;

namespace NotificationsService.Service.Api.Commands;

public sealed record InsertNotifCommand(
    string Title,
    NotificationType Type,
    NotificationCategory Category,
    Guid BatchId,
    string UserId
) : IRequest<bool>;