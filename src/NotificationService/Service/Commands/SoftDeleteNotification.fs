namespace NotificationService.Service.Commands

open System
open MediatR

/// Command for marking a notification as deleted (but not completely deleted from the database).
[<Sealed>]
type internal SoftDeleteNotification(notificationId: Guid) =
    interface IRequest<bool>
    member this.NotificationId = notificationId
