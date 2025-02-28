using System;
using System.Threading.Tasks;
using SimpleBookingSystem.Domain.Entities;

namespace SimpleBookingSystem.Domain.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> BookResourceAsync(int resourceId, int quantity, DateTime startTime, DateTime endTime);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

    }
}
