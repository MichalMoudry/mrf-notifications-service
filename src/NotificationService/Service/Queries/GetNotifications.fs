namespace NotificationService.Service.Queries

open MediatR
open NotificationService.Database.Model.Dto

/// Query for retrieving user's notifications.
[<Sealed>]
type internal GetNotifications(userId: string) =
    interface IRequest<seq<NotificationInformation>>
    member this.UserId = userId
