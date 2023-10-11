using System.Data;
using MediatR;
using NotificationsService.Service.Api.Handlers;

namespace NotificationsService.Service.Commands;

/// <summary>
/// A handler class for InsertNotifCommand.
/// </summary>
public sealed class InsertNotifCommandHandler : IRequestHandler<InsertNotifCommand, bool>
{
    private readonly IDbConnection _connection;
    
    public InsertNotifCommandHandler(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public Task<bool> Handle(InsertNotifCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}