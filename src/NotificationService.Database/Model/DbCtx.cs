using System.Data;

namespace NotificationService.Database.Model;

/// <summary>
/// A class for wrapping an entire DB context for repositories.
/// </summary>
public sealed class DbCtx(IDbConnection dbConn, IDbTransaction tx)
{
    public IDbConnection Connection => dbConn;

    public IDbTransaction Transaction => tx;
}