using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleBookingSystem.Domain.Entities;

namespace SimpleBookingSystem.Domain.Interfaces
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(int id);
        Task AddResourceAsync(Resource resource);
        // Task UpdateResourceAsync(Resource resource);
        // Task DeleteResourceAsync(int id);
    }
}
