using MediatR;
using NotificationsService.Service.Model.Dto;

namespace NotificationsService.Service.Api.Queries;

/// <summary>
/// Query for retrieving user's notifications.
/// </summary>
/// <param name="UserId">Id of a logged in user.</param>
public sealed record GetNotificationsQuery(
    string UserId
) : IRequest<IEnumerable<NotificationDto>>;