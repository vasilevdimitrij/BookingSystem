using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem.Domain.Entities;
using SimpleBookingSystem.Domain.Interfaces;

namespace SimpleBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Resource>> GetResources()
        {
            return await _resourceService.GetAllResourcesAsync();
        }


        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody] Resource resource)
        {
            if (resource == null)
                return BadRequest("Invalid resource data.");

            await _resourceService.AddResourceAsync(resource);
            return CreatedAtAction(nameof(GetResources), new { id = resource.Id }, resource);
        }

    }
}
