namespace NotificationService.Service.Queries

open MediatR

/// A query for obtaining a count of user's unread notifications.
[<Sealed>]
type internal GetNotificationCount(userId: string) =
    interface IRequest<int>
    member this.UserId = userId
