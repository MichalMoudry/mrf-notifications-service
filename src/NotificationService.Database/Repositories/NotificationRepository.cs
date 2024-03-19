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
        => conn.QuerySingleAsync<int>(
            SqlQueries.GetNotificationsCount,
            new { UserId = userId }
        );

    /// <inheritdoc/>
    public Task<IEnumerable<NotificationInformation>> GetNotifications(string userId)
        => conn.QueryAsync<NotificationInformation>(
            SqlQueries.GetNotifications,
            new { UserId = userId }
        );

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