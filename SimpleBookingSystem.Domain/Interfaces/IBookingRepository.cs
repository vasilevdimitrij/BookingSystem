using System;
using System.Threading.Tasks;
using SimpleBookingSystem.Domain.Entities;

namespace SimpleBookingSystem.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> IsResourceAvailable(int resourceId, int quantity, DateTime startTime, DateTime endTime);
        Task AddBookingAsync(Booking booking);
    }
}
