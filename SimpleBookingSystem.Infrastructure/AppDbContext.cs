using Microsoft.EntityFrameworkCore;
using SimpleBookingSystem.Domain.Entities;

namespace SimpleBookingSystem.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
