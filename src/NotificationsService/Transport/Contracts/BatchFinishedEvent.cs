using System.Text.Json.Serialization;
using NotificationsService.Service.Model;

namespace NotificationsService.Transport.Contracts;

/// <summary>
/// A record representing a request for adding a new document batch statistic.
/// </summary>
public sealed record BatchFinishedEvent(
    [property: JsonPropertyName("batch_id")]
    Guid BatchId,
    [property: JsonPropertyName("user_id")]
    string UserId,
    [property: JsonPropertyName("status")]
    BatchStatus Status
);