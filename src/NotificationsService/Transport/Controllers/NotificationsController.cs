﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationsService.Service.Api.Commands;
using NotificationsService.Service.Api.Queries;

namespace NotificationsService.Transport.Controllers;

/// <summary>
/// Controller for Notifications resource.
/// </summary>
[ApiController]
[Authorize]
[Route("[controller]")]
public sealed class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// An API endpoint for obtaining user's unread notifications count.
    /// </summary>
    [HttpGet("Count")]
    public async Task<IResult> GetNotificationsCount()
    {
        var idClaim = HttpContext.User.Claims.First(i => i.Type == "user_id");
        return Results.Ok(
            await _mediator.Send(new GetNotificationCountQuery(idClaim.Value))
        );
    }

    [HttpGet]
    public async Task<IResult> GetNotifications()
    {
        var idClaim = HttpContext.User.Claims.First(i => i.Type == "user_id");
        return Results.Ok(
            await _mediator.Send(new GetNotificationsQuery(idClaim.Value))
        );
    }

    [HttpDelete("{notificationId:guid}")]
    public async Task<IResult> DeleteNotification(Guid notificationId)
    {
        return await _mediator.Send(new MarkDeletedNotifCommand(notificationId))
            ? Results.Ok()
            : Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
}