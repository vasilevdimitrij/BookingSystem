using System;
using System.Threading.Tasks;

namespace SimpleBookingSystem.Domain.Interfaces
{
    public interface IBookingService
    {
        Task<string> BookResourceAsync(int resourceId, int quantity, DateTime startTime, DateTime endTime);
    }
}
