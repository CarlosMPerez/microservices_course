using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Mappers
{
    public static class PlatformMapper
    {
        public static Platform ToModel(this PlatformReadDto dto)
        {
            return new Platform
            {
                Id = dto.Id,
                Name = dto.Name,
                Publisher = dto.Publisher,
                Cost = dto.Cost
            };
        }

        public static Platform ToModel(this PlatformCreateDto dto)
        {
            return new Platform
            {
                Name = dto.Name,
                Publisher = dto.Publisher,
                Cost = dto.Cost
            };
        }

        public static PlatformCreateDto ToCreateDto(this Platform model)
        {
            return new PlatformCreateDto
            {
                Name = model.Name,
                Publisher = model.Publisher,
                Cost = model.Cost
            };
        }

        public static PlatformReadDto ToReadDto(this Platform model)
        {
            return new PlatformReadDto
            {
                Id = model.Id,
                Name = model.Name,
                Publisher = model.Publisher,
                Cost = model.Cost
            };
        }
    }
}