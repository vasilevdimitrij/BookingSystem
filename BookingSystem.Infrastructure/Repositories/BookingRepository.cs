using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Interfaces;

namespace BookingSystem.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsResourceAvailable(int resourceId, int quantity, DateTime startTime, DateTime endTime)
        {
            var existingBookings = await _context.Bookings
                .Where(b => b.ResourceId == resourceId &&
                            b.EndTime > startTime &&
                            b.StartTime < endTime)
                .ToListAsync();

            int bookedQuantity = existingBookings.Sum(b => b.Quantity);
            int availableQuantity = (await _context.Resources.FindAsync(resourceId))?.Quantity ?? 0;

            return (availableQuantity - bookedQuantity) >= quantity;
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

    }
}
