using MediatR;
using NotificationsService.Database.Model;
using NotificationsService.Service.Model;

namespace NotificationsService.Service.Api.Handlers;

public sealed record InsertNotifCommand(
    string Title,
    NotificationType Type,
    NotificationCategory Category,
    string UserId
) : IRequest<bool>;