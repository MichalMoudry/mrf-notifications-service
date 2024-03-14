namespace NotificationService
#nowarn "20"

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open NotificationService.Transport
open Giraffe

[<Sealed>]
module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =
        printfn "Hello from notifications service! ʕ•ᴥ•ʔ"

        let builder = WebApplication.CreateBuilder()
        builder.Services.AddMediatR(fun cfg ->
            cfg.RegisterServicesFromAssemblyContaining<Initializer>() |> ignore
        )
        builder.Services.AddGiraffe()

        let app = builder.Build()
        app.UseGiraffe(Initializer().Initialize())
        app.Run()

        exitCode
