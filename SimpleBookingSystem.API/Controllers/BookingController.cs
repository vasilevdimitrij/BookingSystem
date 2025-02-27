using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SimpleBookingSystem.Domain.Interfaces;

namespace SimpleBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> BookResource(int resourceId, int quantity, DateTime startTime, DateTime endTime)
        {
            var result = await _bookingService.BookResourceAsync(resourceId, quantity, startTime, endTime);
            return Ok(result);
        }
    }
}
