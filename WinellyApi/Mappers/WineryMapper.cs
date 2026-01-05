using WinellyApi.DTOs.Winery;
using WinellyApi.Models;

namespace WinellyApi.Mappers
{
    public static class WineryMapper
    {
        public static WineryDto ToWineryDto(this Winery wineryModel)
        {
            return new WineryDto
            {
                Id = wineryModel.Id,
                Name = wineryModel.Name,
                Region = wineryModel.Region,
                Country = wineryModel.Country,
                EstablishedYear = wineryModel.EstablishedYear,
            };
        }

        public static Winery ToWineryFromCreateDTO(this CreateWineryRequestDto wineryDto)
        {
            return new Winery
            {
                Name = wineryDto.Name,
                Region = wineryDto.Region,
                Country = wineryDto.Country,
                EstablishedYear = wineryDto.EstablishedYear,
            };
        }
    }
}
