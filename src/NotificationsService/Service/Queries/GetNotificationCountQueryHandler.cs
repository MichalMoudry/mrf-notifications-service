using System.Data;
using Dapper;
using MediatR;
using NotificationsService.Service.Api.Queries;

namespace NotificationsService.Service.Queries;

/// <summary>
/// A handler class for the GetNotificationCountQuery query.
/// </summary>
public sealed class GetNotificationCountQueryHandler : IRequestHandler<GetNotificationCountQuery, int>
{
    private readonly IDbConnection _connection;

    public GetNotificationCountQueryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<int> Handle(GetNotificationCountQuery request, CancellationToken cancellationToken)
    {
        var res = await _connection.QueryAsync<int>(
            $"SELECT COUNT(Id) FROM NotificationsDb.Notifications WHERE UserId = '{request.UserId}'"
        );
        return 5;
    }
}