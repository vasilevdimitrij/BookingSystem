using System;
using System.Threading.Tasks;
using SimpleBookingSystem.Domain.Entities;
using SimpleBookingSystem.Domain.Interfaces;

namespace SimpleBookingSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;

        public BookingService(IBookingRepository bookingRepository, IResourceRepository resourceRepository)
        {
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
        }

        public async Task<string> BookResourceAsync(int resourceId, int quantity, DateTime startTime, DateTime endTime)
        {
            if (!await _bookingRepository.IsResourceAvailable(resourceId, quantity, startTime, endTime))
                return "Resource is not available for the selected time and quantity.";

            var booking = new Booking
            {
                ResourceId = resourceId,
                Quantity = quantity,
                StartTime = startTime,
                EndTime = endTime
            };

            await _bookingRepository.AddBookingAsync(booking);
            return $"Booking successful! Booking ID: {booking.Id}";
        }
    }
}
