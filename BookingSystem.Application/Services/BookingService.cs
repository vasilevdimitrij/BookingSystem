using System;
using System.Threading.Tasks;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Interfaces;

namespace BookingSystem.Application.Services
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

        public async Task<Booking> BookResourceAsync(int resourceId, int quantity, DateTime startTime, DateTime endTime)
        {
            if (!await _bookingRepository.IsResourceAvailable(resourceId, quantity, startTime, endTime))
                throw new ArgumentException("Resource is not available for the selected time and quantity.");

            var booking = new Booking
            {
                ResourceId = resourceId,
                Quantity = quantity,
                StartTime = startTime,
                EndTime = endTime
            };

            return await _bookingRepository.AddBookingAsync(booking);
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }
    }
}
