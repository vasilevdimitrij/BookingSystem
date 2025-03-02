using Microsoft.EntityFrameworkCore;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Interfaces;

namespace BookingSystem.Infrastructure.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly AppDbContext _context;

        public ResourceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _context.Resources.Where(x => x.Quantity > 0).ToListAsync();
        }

        public async Task<Resource> GetResourceByIdAsync(int id)
        {
            var resource = await _context.Resources.FirstOrDefaultAsync(x => x.Id == id);
            if (resource == null)
            {
                throw new KeyNotFoundException($"Resource with Id {id} not found.");
            }
            return resource;
        }

        public async Task AddResourceAsync(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResourceAsync(Resource resource)
        {
            var existingResource = await _context.Resources.AsNoTracking().FirstOrDefaultAsync(x => x.Id == resource.Id);

            if (existingResource is null)
            {
                throw new KeyNotFoundException($"Resource with Id {resource.Id} not found.");
            }
            _context.Resources.Attach(resource);
            _context.Resources.Update(resource);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteResourceAsync(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Resource with Id {id} not found.");
            }
        }
    }
}
