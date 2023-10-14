namespace NotificationsService.Config;

/// <summary>
/// A record encapsulating credentials for Firebase.
/// </summary>
internal sealed record GoogleCredentials(
    string Type,
    string ProjectId,
    string PrivateKeyId,
    string PrivateKey,
    string ClientEmail,
    string ClientId,
    string AuthUri,
    string TokenUri,
    string AuthProviderCertUrl,
    string ClientCertUrl,
    string UniverseDomain
);