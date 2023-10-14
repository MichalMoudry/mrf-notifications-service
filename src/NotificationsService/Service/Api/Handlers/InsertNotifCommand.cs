using MediatR;
using NotificationsService.Database.Model;

namespace NotificationsService.Service.Api.Handlers;

public sealed record InsertNotifCommand(
    string Title,
    NotificationType Type,
    string UserId
) : IRequest<bool>;