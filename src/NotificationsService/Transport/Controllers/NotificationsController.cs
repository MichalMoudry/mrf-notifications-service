using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NotificationsService.Transport.Controllers;

/// <summary>
/// Controller for Notifications resource.
/// </summary>
[ApiController]
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

    [HttpGet("/count")]
    public IResult GetNotificationsCount()
    {
        return Results.Ok(5);
    }

    [HttpGet]
    public IResult GetNotifications()
    {
        return Results.Ok("Test");
    }

    [HttpDelete("/{notificationId:guid}")]
    public IResult DeleteNotification(Guid notificationId)
    {
        _logger.LogInformation($"Delete notification with ID '{notificationId}'.");
        return Results.Ok();
    }
}