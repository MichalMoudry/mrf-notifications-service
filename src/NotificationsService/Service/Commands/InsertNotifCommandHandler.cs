﻿using System.Data;
using Dapper;
using MediatR;
using NotificationsService.Database.Queries;
using NotificationsService.Service.Api.Commands;
using NotificationsService.Service.Helpers;

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
    
    public async Task<bool> Handle(InsertNotifCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var content = NotificationContentHelper.GetNotificationContent(request.Category);
        if (content == null) return false;
        content = string.Format(content, request.BatchId);

        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        var res = await _connection.ExecuteAsync(
            SqlQueries.InsertNotification,
            new
            {
                Id = Guid.NewGuid(),
                request.Title,
                Content = content,
                request.Type,
                request.UserId,
                IsDeleted = false,
                Now = now
            },
            transaction: transaction
        );
        transaction.Commit();
        return res >= 0;
    }
}