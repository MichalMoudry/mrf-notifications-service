namespace NotificationService
#nowarn "20"

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open NotificationService.Tranport.Contracts

[<Sealed>]
module Program =
    open System.Threading
    let exitCode = 0

    let app =
        choose [ GET >=> choose
            [ path "/health" >=> OK "Healthy"
              path "/temp" >=> OK (System.Text.Json.JsonSerializer.Serialize({ Id = System.Guid.NewGuid(); TestName = ""; DateAdded = System.DateTimeOffset.Now })) ]
        ]

    [<EntryPoint>]
    let main args =
        let ctx = new CancellationTokenSource()
        let cfg = { defaultConfig with cancellationToken = ctx.Token }

        let _, server = startWebServerAsync cfg app
        Async.Start(server, ctx.Token)
        System.Console.ReadKey true |> ignore

        ctx.Cancel()

        exitCode
