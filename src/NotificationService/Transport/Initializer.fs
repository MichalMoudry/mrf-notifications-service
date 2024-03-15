namespace NotificationService.Transport

open Giraffe
open MediatR
open Microsoft.AspNetCore.Http
open NotificationService.Service.Queries

type Initializer() =
    let getNotificationsCount : HttpHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let mediatr = ctx.GetService<IMediator>()
                //let userId = ctx.User.Claims |> Seq.find(fun i -> i.Type = "user_id")

                let! res = mediatr.Send(GetNotificationCountQuery("ctx.User.Identity.Name"))
                return! Successful.ok (text (string(res))) next ctx
            }

    member this.Initialize() =
        choose [
            GET >=> choose [
                route "/notifications/count" >=> getNotificationsCount
                route "/health" >=> Successful.NO_CONTENT
            ]
        ]
