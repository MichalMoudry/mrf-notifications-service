namespace NotificationService
#nowarn "20"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Server.Kestrel.Core
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open NotificationService.Database.Api
open NotificationService.Transport
open Giraffe

[<Sealed>]
module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =
        printfn "Hello from notifications service! ʕ•ᴥ•ʔ"

        let builder = WebApplication.CreateSlimBuilder(args)
        builder.Services.AddMediatR(fun cfg ->
            cfg.RegisterServicesFromAssemblyContaining<Initializer>() |> ignore
        )
        builder.Services.AddGiraffe()
        builder.Services.Configure<KestrelServerOptions>(
            fun (i: KestrelServerOptions) -> i.AddServerHeader <- false
        )

        let dbConnectionString =
            match builder.Environment.IsDevelopment() with
            | true -> builder.Configuration["DbConnection"]
            | false -> Environment.GetEnvironmentVariable("DB_CONN")
        builder.Services
            .AddDbConnection(dbConnectionString)
            .AddRepositories()

        let app = builder.Build()
        app.UseGiraffe(Initializer().Initialize())
        app.Run()

        exitCode
