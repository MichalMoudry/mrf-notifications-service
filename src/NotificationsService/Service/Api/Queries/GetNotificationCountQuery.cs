using MediatR;

namespace NotificationsService.Service.Api.Queries;

/// <summary>
/// A query for obtaining a count of user's unread notifications.
/// </summary>
/// <param name="UserId">Id of a specific user.</param>
public sealed record GetNotificationCountQuery(string UserId) : IRequest<int>;