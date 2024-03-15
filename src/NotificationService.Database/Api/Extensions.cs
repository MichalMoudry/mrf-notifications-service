using System.Data;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Database.Repositories;
using Npgsql;

namespace NotificationService.Database.Api;

/// <summary>
/// A class with extension methods related to the database layer.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Extension method for registering a transient database connection service.
    /// </summary>
    public static IServiceCollection AddDbConnection(
        this IServiceCollection services,
        string connStr)
        => services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(connStr));

    /// <summary>
    /// An extension method for registering/adding repositories as services.
    /// </summary>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient<INotificationRepository, NotificationRepository>();
    }
}