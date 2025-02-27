using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleBookingSystem.Domain.Entities;
using SimpleBookingSystem.Domain.Interfaces;

namespace SimpleBookingSystem.Application.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _resourceRepository.GetAllResourcesAsync();
        }

        public async Task<Resource> GetResourceByIdAsync(int id)
        {
            return await _resourceRepository.GetResourceByIdAsync(id);
        }

        public async Task AddResourceAsync(Resource resource)
        {
            await _resourceRepository.AddResourceAsync(resource);
        }

        public async Task UpdateResourceAsync(Resource resource)
        {
            await _resourceRepository.UpdateResourceAsync(resource);
        }

        public async Task DeleteResourceAsync(int id)
        {
            await _resourceRepository.DeleteResourceAsync(id);
        }
    }
}
