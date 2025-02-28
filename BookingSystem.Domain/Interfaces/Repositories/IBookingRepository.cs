using System;
using System.Threading.Tasks;
using BookingSystem.Domain.Entities;

namespace BookingSystem.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> IsResourceAvailable(int resourceId, int quantity, DateTime startTime, DateTime endTime);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

    }
}
