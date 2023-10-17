using NotificationsService.Service.Model;

namespace NotificationsService.Service.Helpers;

/// <summary>
/// Helper class for obtaining contents for specific notification categories.
/// </summary>
public static class NotificationContentHelper
{
    private static readonly Dictionary<NotificationCategory, string> NotificationContents = new()
    {
        { NotificationCategory.BatchFinished, "Batch '{0}' has finished processing." }
    };

    public static string? GetNotificationContent(NotificationCategory category)
    {
        var lookupResult = NotificationContents.TryGetValue(
            category,
            out var result
        );
        return lookupResult
            ? result
            : null;
    }
}