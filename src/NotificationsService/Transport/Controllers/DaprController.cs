using Microsoft.AspNetCore.Mvc;

namespace NotificationsService.Transport.Controllers;

/// <summary>
/// Controller for with endpoints for Dapr runtime.
/// </summary>
[ApiController]
[Route("[controller]")]
public sealed class DaprController : ControllerBase
{
    private readonly ILogger<DaprController> _logger;

    public DaprController(ILogger<DaprController> logger)
    {
        _logger = logger;
    }
}