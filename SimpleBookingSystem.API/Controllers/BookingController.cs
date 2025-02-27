using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SimpleBookingSystem.Domain.Interfaces;
using SimpleBookingSystem.Application.Validation;
using SimpleBookingSystem.Domain.Entities;

namespace SimpleBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly BookingValidator _bookingValidator;

        public BookingController(IBookingService bookingService, BookingValidator bookingValidator)
        {
            _bookingService = bookingService;
            _bookingValidator = bookingValidator;
        }

        [HttpPost]
        public async Task<IActionResult> BookResource(int resourceId, int quantity, DateTime startTime, DateTime endTime)
        {
            var validationResult = await _bookingValidator.ValidateAsync(new Booking { ResourceId = resourceId, Quantity = quantity, StartTime = startTime, EndTime = endTime });
            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });
            var result = await _bookingService.BookResourceAsync(resourceId, quantity, startTime, endTime);
            return Ok(result);
        }
    }
}
