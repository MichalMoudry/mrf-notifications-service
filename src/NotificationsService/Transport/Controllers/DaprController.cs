using Dapr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationsService.Database.Model;
using NotificationsService.Service.Api.Handlers;
using NotificationsService.Transport.Contracts;

namespace NotificationsService.Transport.Controllers;

/// <summary>
/// Controller for with endpoints for the Dapr runtime.
/// </summary>
[ApiController]
[Route("[controller]")]
public sealed class DaprController : ControllerBase
{
    private readonly ILogger<DaprController> _logger;

    private readonly IMediator _mediator;

    private readonly IValidator<BatchStatRequest> _batchStatValidator;

    public DaprController(
        ILogger<DaprController> logger,
        IValidator<BatchStatRequest> batchStatValidator,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        _batchStatValidator = batchStatValidator;
    }

    /// <summary>
    /// An endpoint method for handling HTTP requests for sending stats about finished document batches.
    /// </summary>
    [HttpPost]
    [Topic("mrf_pub_sub", "batch-finish")]
    public async Task<IResult> BatchCompleted([FromBody] CloudEvent<BatchStatRequest> request)
    {
        var validationResult = await _batchStatValidator
            .ValidateAsync(request.Data);
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }
        _logger.LogInformation("Received an information about a completed batch");

        var res = await _mediator.Send(
            new InsertNotifCommand(
                "Document batch processing has been completed",
                request.Data.Status == BatchStatus.Success
                    ? NotificationType.Positive
                    : NotificationType.Negative,
                request.Data.UserId
            )
        );
        return !res
            ? Results.StatusCode(StatusCodes.Status500InternalServerError)
            : Results.Ok();
    }
}