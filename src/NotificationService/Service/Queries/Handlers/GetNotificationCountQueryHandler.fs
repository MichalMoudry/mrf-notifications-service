namespace NotificationService.Service.Queries.Handlers

open MediatR
open NotificationService.Database.Api
open NotificationService.Service.Queries

/// A handler class for the GetNotificationCountQuery query.
type GetNotificationCountQueryHandler(repository: INotificationRepository) =
    interface IRequestHandler<GetNotificationCountQuery, int> with
        member this.Handle(request, cancellationToken) =
            task {
                if cancellationToken.IsCancellationRequested then
                    return 0
                else
                    return! repository.GetNotificationsCount(request.UserId)
            }
