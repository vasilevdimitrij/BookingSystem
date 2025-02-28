using System;
using System.Threading.Tasks;
using BookingSystem.Domain.Entities;

namespace BookingSystem.Domain.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> BookResourceAsync(int resourceId, int quantity, DateTime startTime, DateTime endTime);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

    }
}
