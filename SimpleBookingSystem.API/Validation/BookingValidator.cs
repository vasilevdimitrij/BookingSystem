using FluentValidation;
using SimpleBookingSystem.Domain.Entities;

namespace SimpleBookingSystem.Application.Validation
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(b => b.ResourceId)
                .GreaterThan(0).WithMessage("Valid Resource ID is required.");

            RuleFor(b => b.Quantity)
                .GreaterThan(0).WithMessage("Booking quantity must be greater than zero.");

            RuleFor(b => b.StartTime)
                .LessThan(b => b.EndTime).WithMessage("Start time must be before end time.");
        }
    }
}
