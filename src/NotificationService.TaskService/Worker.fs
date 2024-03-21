namespace NotificationService.TaskService

open System
open System.Threading
open System.Threading.Tasks
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open NotificationService.Database.Api

type Worker(logger: ILogger<Worker>, notificationRepo: INotificationRepository) =
    inherit BackgroundService()

    override _.ExecuteAsync(ct: CancellationToken) =
        task {
            while not ct.IsCancellationRequested do
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now)
                let! notificationCount = notificationRepo.GetNotificationsCount("user_id")
                logger.LogInformation("Notification count: {count}", notificationCount)
                do! Task.Delay(1_000)
        }