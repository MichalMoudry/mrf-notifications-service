using MediatR;

namespace NotificationsService.Service.Api.Handlers;

public sealed record InsertNotifCommand() : IRequest<bool>;