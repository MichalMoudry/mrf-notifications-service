namespace NotificationService.Service.Queries.Handlers

open MediatR
open NotificationService.Database.Api
open NotificationService.Database.Model.Dto
open NotificationService.Service.Queries

/// A query handler class for GetNotificationsQuery query.
[<Sealed>]
type internal GetNotificationsHandler(repository: INotificationRepository) =
    interface IRequestHandler<GetNotifications, seq<NotificationInformation>> with
        member this.Handle(request, cancellationToken) =
            task {
                if cancellationToken.IsCancellationRequested then
                    return Seq.empty<NotificationInformation>
                else
                    return! repository.GetNotifications(request.UserId)
            }