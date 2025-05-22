using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Mappers;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController(IPlatformRepo repository) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platforms = repository
                                .GetAllPlatforms()
                                .Select(p => p.ToReadDto())
                                .ToList();

            return Ok(platforms);
        }

        [HttpGet("{id}", Name = "GetPlatformById")] // to be used by CreatedAtRoute below
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platform = repository.GetPlatfomById(id);
            if (platform != null) return Ok(platform.ToReadDto());
            else return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto newPlatform)
        {
            var model = newPlatform.ToModel();
            repository.CreatePlatform(model);
            repository.SaveChanges();

            var readDto = model.ToReadDto();

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = readDto.Id }, readDto);
        }

    }
}