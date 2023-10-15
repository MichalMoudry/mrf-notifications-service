using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    private readonly ILogger<NotificationsController> _logger;

    private readonly IMediator _mediator;

    public NotificationsController(ILogger<NotificationsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// An API endpoint for obtaining user's unread notifications count.
    /// </summary>
    [HttpGet("Count")]
    public async Task<IResult> GetNotificationsCount()
    {
        var id = HttpContext.User.Claims.First(i => i.Type == "user_id");
        return Results.Ok(
            await _mediator.Send(new GetNotificationCountQuery(id.Value))
        );
    }

    [HttpGet]
    public IResult GetNotifications()
    {
        return Results.Ok("Test");
    }

    [HttpDelete("/{notificationId:guid}")]
    public IResult DeleteNotification(Guid notificationId)
    {
        return Results.Ok();
    }
}