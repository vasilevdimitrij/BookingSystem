using FluentValidation;
using SimpleBookingSystem.Domain.Entities;

namespace SimpleBookingSystem.Application.Validation
{
    public class ResourceValidator : AbstractValidator<Resource>
    {
        public ResourceValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Resource name is required.")
                .MinimumLength(3).WithMessage("Resource name must be at least 3 characters long.");

            RuleFor(r => r.Quantity)
                .GreaterThan(0).WithMessage("Resource quantity must be greater than zero.");
        }
    }
}
