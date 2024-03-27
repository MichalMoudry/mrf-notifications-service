namespace NotificationService.TaskService

open System
open System.Threading
open System.Threading.Tasks
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open NotificationService.Database.Api
open NotificationService.Database.Model.Domain

[<Sealed>]
type internal Worker(
    logger: ILogger<Worker>,
    notificationRepo: INotificationRepository) =
    inherit BackgroundService()

    override _.ExecuteAsync(ct: CancellationToken) =
        task {
            while not ct.IsCancellationRequested do
                logger.LogInformation(
                    "Worker running at: {time}",
                    DateTimeOffset.Now
                )

                let! notificationCount =
                    notificationRepo.GetNotificationsCount("user_id")
                logger.LogInformation(
                    "Notification count: {count}",
                    notificationCount
                )

                do! notificationRepo.AddNotification(Notification(
                    ContentKey = "test_notification",
                    Type = NotificationType.Info,
                    UserId = "user_id"
                ))
                do! Task.Delay(3_000)
        }