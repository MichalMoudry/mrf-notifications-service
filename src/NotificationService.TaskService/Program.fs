namespace NotificationService.TaskService

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open NotificationService.Database.Api

[<Sealed>]
module Program =
    [<EntryPoint>]
    let main args =
        let builder = Host.CreateApplicationBuilder(args)

        let dbConnectionString =
            match builder.Environment.IsDevelopment() with
            | true -> builder.Configuration["DbConnection"]
            | false -> Environment.GetEnvironmentVariable("DB_CONN")
        builder.Services
            .AddDbConnection(dbConnectionString)
            .AddRepositories() |> ignore

        builder.Services.AddHostedService<Worker>() |> ignore

        builder.Build().Run()

        0 // exit code