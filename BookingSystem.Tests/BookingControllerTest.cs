using Moq;
using BookingSystem.Domain.Interfaces;
using BookingSystem.Application.Validation;
using BookingSystem.API.Controllers;
using BookingSystem.Domain.Entities;


namespace BookingSystem.Tests.Controllers
{
    public class BookingControllerTests
    {
        private readonly Mock<IBookingService> _mockBookingService;
        private readonly Mock<BookingValidator> _mockBookingValidator;
        private readonly BookingController _controller;

        public BookingControllerTests()
        {
            _mockBookingService = new Mock<IBookingService>();
            _mockBookingValidator = new Mock<BookingValidator>();
            _controller = new BookingController(_mockBookingService.Object, _mockBookingValidator.Object);
        }

        [Fact]
        public async Task GetBookings_ReturnsOk()
        {
            var bookings = new List<Booking>
            {
                new Booking { ResourceId = 1, Quantity = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) },
                new Booking { ResourceId = 2, Quantity = 2, StartTime = DateTime.Now.AddHours(1), EndTime = DateTime.Now.AddHours(2) }
            };

            _mockBookingService.Setup(s => s.GetAllBookingsAsync()).ReturnsAsync(bookings);

            var result = await _controller.GetBookings();

            var okResult = Assert.IsType<List<Booking>>(result);
            Assert.Equal(2, okResult.Count);
        }
    }
}
