namespace NotificationService.Service.Commands.Handlers

open System.Data
open MediatR
open NotificationService.Database.Api
open NotificationService.Service.Commands

/// A handler class for the SoftDeleteNotification command. 
[<Sealed>]
type internal SoftDeleteNotificationHandler(
    conn: IDbConnection,
    repository: INotificationRepository) =
    interface IRequestHandler<SoftDeleteNotification, bool> with
        member this.Handle(request, cancellationToken) =
            task {
                if cancellationToken.IsCancellationRequested then
                    return false
                else
                    conn.Open()
                    use tx = conn.BeginTransaction()

                    repository.SoftDeleteNotification(tx, request.NotificationId)
                    |> Async.AwaitTask
                    |> Async.RunSynchronously
                    tx.Commit()

                    return true
            }
