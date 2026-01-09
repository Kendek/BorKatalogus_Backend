using WinellyApi.DTOs.Wine;
using WinellyApi.Models;

namespace WinellyApi.Mappers
{
    public static class WineMapper
    {
        public static WineDto ToWineDto(this Wine wineModel)
        {
            return new WineDto
            {
                Id = wineModel.Id,
                Name = wineModel.Name,
                Type = wineModel.Type,
                Year = wineModel.Year,
                Price = wineModel.Price,
                AlcoholContent = wineModel.AlcoholContent,
                WineryId = wineModel.WineryId,
            };
        }

        public static Wine ToWineFromCreateDTO(this CreateWineRequestDto wineDto, int wineryId)
        {
            return new Wine
            {
                Name = wineDto.Name,
                Type = wineDto.Type,
                Year = wineDto.Year,
                Price = wineDto.Price,
                AlcoholContent = wineDto.AlcoholContent,
                WineryId = wineryId,
            };
        }
        public static Wine ToWineFromUpdateDTO(this UpdateWineRequestDto wineDto)
        {
            return new Wine
            {
                Name = wineDto.Name,
                Type = wineDto.Type,
                Year = wineDto.Year,
                Price = wineDto.Price,
                AlcoholContent = wineDto.AlcoholContent,
            };
        }
    }
}
