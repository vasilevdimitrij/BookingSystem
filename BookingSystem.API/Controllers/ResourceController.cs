using Microsoft.AspNetCore.Mvc;
using BookingSystem.Application.Validation;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Interfaces;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly ResourceValidator _resourceValidator;


        public ResourceController(IResourceService resourceService, ResourceValidator resourceValidator)
        {
            _resourceService = resourceService;
            _resourceValidator = resourceValidator;
        }


        [HttpGet]
        public async Task<IEnumerable<Resource>> GetResources()
        {
            return await _resourceService.GetAllResourcesAsync();
        }


        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody] Resource resource)
        {
            var validationResult = await _resourceValidator.ValidateAsync(resource);
            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            await _resourceService.AddResourceAsync(resource);
            return CreatedAtAction(nameof(GetResources), new { id = resource.Id }, resource);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResource([FromBody] Resource resource)
        {
            var validationResult = await _resourceValidator.ValidateAsync(resource);
            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            await _resourceService.UpdateResourceAsync(resource);
            return Ok(resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            await _resourceService.DeleteResourceAsync(id);
            return NoContent();
        }

    }
}
