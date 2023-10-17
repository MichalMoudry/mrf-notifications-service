using System.Data;
using Dapper;
using MediatR;
using NotificationsService.Service.Api.Commands;

namespace NotificationsService.Service.Commands;

/// <summary>
/// A handler class for the MarkDeletedNotifCommand command. 
/// </summary>
public sealed class MarkDeletedNotifCommandHandler : IRequestHandler<MarkDeletedNotifCommand, bool>
{
    private readonly IDbConnection _connection;

    public MarkDeletedNotifCommandHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> Handle(MarkDeletedNotifCommand request, CancellationToken cancellationToken)
    {
        using var transaction = _connection.BeginTransaction();
        await _connection.ExecuteAsync(
            "UPDATE notifications.Notifications SET IsDeleted = 1 WHERE Id = @NotificationId;",
            new { request.NotificationId },
            transaction: transaction
        );
        transaction.Commit();
        return true;
    }
}