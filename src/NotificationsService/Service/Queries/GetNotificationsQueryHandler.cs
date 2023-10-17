using System.Data;
using Dapper;
using MediatR;
using NotificationsService.Database.Queries;
using NotificationsService.Service.Api.Queries;
using NotificationsService.Service.Model.Dto;

namespace NotificationsService.Service.Queries;

/// <summary>
/// A query handler class for GetNotificationsQuery query.
/// </summary>
public sealed class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, IEnumerable<NotificationDto>>
{
    private readonly IDbConnection _connection;

    public GetNotificationsQueryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<NotificationDto>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
    {
        return await _connection.QueryAsync<NotificationDto>(
            SqlQueries.GetNotifications,
            new { request.UserId }
        );
    }
}