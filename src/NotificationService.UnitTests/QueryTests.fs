module NotificationService.UnitTests

open MediatR
open Moq
open NUnit.Framework
open NotificationService.Database.Api
open NotificationService.Service.Queries.Handlers

[<Test>]
let Test1 () =
    let repository = Mock.Of<INotificationRepository>()
    let query = GetNotificationCountQueryHandler(repository) :> IRequestHandler
    Assert.Pass()