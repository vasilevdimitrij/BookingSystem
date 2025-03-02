using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Exceptions;
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
            var resource = await _resourceRepository.GetResourceByIdAsync(resourceId);

            if (resource.Quantity < quantity)
            {
                throw new ResourceQuantityException("Not enough resource quantity available.");
            }

            if (!await _bookingRepository.IsResourceAvailable(resourceId, quantity, startTime, endTime))
            {
                throw new BookingConflictException("Resource is not available for the selected time and quantity.");
            }

            resource.Quantity -= quantity;
            await _resourceRepository.UpdateResourceAsync(resource);

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
