using System.Data;
using NotificationService.Database.Model.Domain;
using NotificationService.Database.Model.Dto;

namespace NotificationService.Database.Api;

/// <summary>
/// A repository for handling database operations for notifications.
/// </summary>
public interface INotificationRepository
{
    /// <summary>
    /// Method for obtaining a number of notifications awaiting a user.
    /// </summary>
    Task<int> GetNotificationsCount(string userId);

    /// <summary>
    /// Method for obtaining a collection of information about user's notifications.
    /// </summary>
    Task<IEnumerable<NotificationInformation>> GetNotifications(string userId);

    /// <summary>
    /// Method for adding a new notification into the database.
    /// </summary>
    Task AddNotification(Notification notification);

    /// <summary>
    /// Method for soft deleting a specific notification.
    /// </summary>
    Task SoftDeleteNotification(IDbTransaction tx, Guid notificationId);

    /// <summary>
    /// Method for deleting all soft deleted notifications in the database.
    /// </summary>
    Task HardDeleteNotifications();
}