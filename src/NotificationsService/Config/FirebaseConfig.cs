using System.Text.Json;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace NotificationsService.Config;

/// <summary>
/// An internal class providing helper methods for Firebase's configuration.
/// </summary>
internal static class FirebaseConfig
{
    private const string ProjectId = "ocr-microservice-project";
    
    /// <summary>
    /// Method for obtaining Firebase's configuration.
    /// </summary>
    public static AppOptions GetFirebaseConfig()
    {
        return new AppOptions
        {
            Credential = GoogleCredential.FromJson(CreateFirebaseCredentials()),
            ProjectId = ProjectId
        };
    }

    /// <summary>
    /// Method for creating Firebase credentials based on environment values.
    /// </summary>
    private static string CreateFirebaseCredentials()
    {
        return JsonSerializer.Serialize(
            new GoogleCredentials(
                Environment.GetEnvironmentVariable("FB_TYPE") ?? "",
                ProjectId,
                Environment.GetEnvironmentVariable("FB_PRIV_KEY_ID") ?? "",
                (Environment.GetEnvironmentVariable("FB_PRIV_KEY") ?? "").Replace(@"\\n", @"\n"),
                Environment.GetEnvironmentVariable("FB_CLIENT_EMAIL") ?? "",
                Environment.GetEnvironmentVariable("FB_CLIENT_ID") ?? "",
                "https://accounts.google.com/o/oauth2/auth",
                "https://oauth2.googleapis.com/token",
                "https://www.googleapis.com/oauth2/v1/certs",
                Environment.GetEnvironmentVariable("FB_CLIENT_CERT_URL") ?? "",
                "googleapis.com"
            )
        );
    }

    /// <summary>
    /// A method for obtaining an instance of a FirebaseAuth class.
    /// </summary>
    /// <returns>An instance of the FirebaseAuth class.</returns>
    public static FirebaseAuth GetFirebaseAuth()
        => FirebaseAuth.GetAuth(FirebaseApp.DefaultInstance);
}