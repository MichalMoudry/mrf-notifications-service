using FluentValidation;
using NotificationsService.Transport.Contracts;

namespace NotificationsService.Transport.Validation;

/// <summary>
/// A validator class for BatchStatRequest record.
/// </summary>
public sealed class BatchStatRequestValidator : AbstractValidator<BatchStatRequest>
{
    public BatchStatRequestValidator()
    {
        RuleFor(i => i.StartDate)
            .NotEmpty();
        RuleFor(i => i.EndDate)
            .NotEmpty()
            .GreaterThan(i => i.StartDate);
        RuleFor(i => i.Status)
            .NotNull()
            .IsInEnum();
        RuleFor(i => i.NumberOfDocuments)
            .NotEmpty()
            .GreaterThan(0);
    }
}