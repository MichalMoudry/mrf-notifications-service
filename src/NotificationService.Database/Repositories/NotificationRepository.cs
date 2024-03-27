using System.Data;
using Dapper;
using NotificationService.Database.Api;
using NotificationService.Database.Model.Domain;
using NotificationService.Database.Model.Dto;
using NotificationService.Database.Queries;

namespace NotificationService.Database.Repositories;

/// <inheritdoc/>
public sealed class NotificationRepository(IDbConnection conn) : INotificationRepository
{
    /// <inheritdoc/>
    public Task<int> GetNotificationsCount(string userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        return conn.QuerySingleAsync<int>(
            SqlQueries.GetNotificationsCount,
            parameters
        );
    }

    /// <inheritdoc/>
    public Task<IEnumerable<NotificationInformation>> GetNotifications(string userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        return conn.QueryAsync<NotificationInformation>(
            SqlQueries.GetNotifications,
            parameters
        );
    }

    /// <inheritdoc/>
    public Task AddNotification(Notification notification)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task SoftDeleteNotification(IDbTransaction tx, Guid notificationId)
        => await conn.ExecuteAsync(
            SqlQueries.SoftDeleteNotification,
            new { NotificationId = notificationId },
            tx
        );

    /// <inheritdoc/>
    public Task HardDeleteNotifications()
    {
        throw new NotImplementedException();
    }
}