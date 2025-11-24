using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Models.DTOS;
using Security.Repositories;
using Security.Services;

namespace Security.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _service;
        public AnimalController(IAnimalService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _service.GetAllAnimalsAsync();
            return Ok(animals);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(Guid id)
        {
            var animal = await _service.GetAnimalByIdAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalDto animal)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAnimal = await _service.CreateAnimalAsync(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = createdAnimal.Id }, createdAnimal);
        }
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateAnimal(Guid id, [FromBody] UpdateAnimalDto animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedAnimal = await _service.UpdateAnimalAsync(animal, id);
            return CreatedAtAction(nameof(GetAnimalById), new { id = updatedAnimal.Id }, updatedAnimal);


        }
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteAnimal(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.DeleteAnimalAsync(id);
            return NoContent();
        }
    }
}
