[<Sealed>]
module NotificationService.UnitTests

open System.Threading
open MediatR
open NSubstitute
open NUnit.Framework
open NotificationService.Database.Api
open NotificationService.Service.Queries
open NotificationService.Service.Queries.Handlers

[<TestCase("test_user_1", 5)>]
let Test1 (userId: string, expectedNotificationCount: int) =
    task {
        let repository = Substitute.For<INotificationRepository>()
        repository
            .GetNotificationsCount(userId)
            .Returns(expectedNotificationCount)
            |>ignore
        let query = GetNotificationCount(userId)
        let queryHandler =
            GetNotificationCountHandler(repository)
            :> IRequestHandler<GetNotificationCount, int>

        let! result = queryHandler.Handle(query, CancellationToken.None)
        Assert.That(result, Is.EqualTo(result))
    }