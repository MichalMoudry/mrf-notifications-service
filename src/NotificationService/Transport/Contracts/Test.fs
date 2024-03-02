namespace NotificationService.Tranport.Contracts

open System
open System.Text.Json.Serialization

type Test = {
    [<JsonPropertyName("id")>] Id: Guid
    [<JsonPropertyName("test_name")>] TestName: string
    [<JsonPropertyName("date_added")>] DateAdded: DateTimeOffset
}