using WinellyApi.DTOs.Grape;
using WinellyApi.DTOs.Wine;
using WinellyApi.Models;

namespace WinellyApi.Mappers
{
    public static class GrapeMapper
    {
        public static GrapeDto ToGrapeDto(this Grape grapeModel)
        {
            return new GrapeDto
            {
                Id = grapeModel.Id,
                Name = grapeModel.Name,
                Color = grapeModel.Color,
                Taste = grapeModel.Taste,
                Wines = grapeModel.Wine_GrapeConnections
                    .Select(x => new WineDto
                    {
                        Id = x.Wine.Id,
                        Name = x.Wine.Name,
                        Type = x.Wine.Type,
                        Year = x.Wine.Year,
                        Price = x.Wine.Price,
                        AlcoholContent = x.Wine.AlcoholContent,
                    })
                    .ToList()
            };
        }

        public static Grape ToGrapeFromCreateDto(this CreateGrapeRequestDto grapeDto)
        {
            return new Grape
            {
                Name = grapeDto.Name,
                Color = grapeDto.Color,
                Taste = grapeDto.Taste
            };
        }
    }
}
