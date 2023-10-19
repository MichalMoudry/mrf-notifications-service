using NotificationsService.Service.Model;

namespace NotificationsService.Transport.Contracts;

/// <summary>
/// A record representing a request for adding a new document batch statistic.
/// </summary>
public sealed record BatchFinishedEvent(
    Guid BatchId,
    string UserId,
    BatchStatus Status
);