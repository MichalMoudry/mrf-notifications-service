using FluentValidation;
using NotificationsService.Transport.Contracts;

namespace NotificationsService.Transport.Validation;

/// <summary>
/// A validator class for BatchStatRequest record.
/// </summary>
public sealed class BatchFinishedEventValidator : AbstractValidator<BatchFinishedEvent>
{
    public BatchFinishedEventValidator()
    {
        RuleFor(i => i.Status)
            .NotNull()
            .IsInEnum();
    }
}