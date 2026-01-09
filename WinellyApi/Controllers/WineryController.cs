using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinellyApi.Data;
using WinellyApi.DTOs.Wine;
using WinellyApi.DTOs.Winery;
using WinellyApi.Mappers;

namespace WinellyApi.Controllers
{
    [Route("api/winery")]
    [ApiController]
    public class WineryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WineryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetWineries()
        {
            var wineries = await _context.Wineries.Include(x => x.Wines).ToListAsync();
            var wineriesDto = wineries.Select(winery => winery.ToWineryDto());
            return Ok(wineriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWineryById(int id)
        {
            var winery = await _context.Wineries.Include(x => x.Wines).FirstOrDefaultAsync(x => x.Id == id);
            if (winery == null)
            {
                return NotFound();
            }
            return Ok(winery.ToWineryDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateWinery([FromBody] CreateWineryRequestDto wineryDto)
        {
            var wineryModel = wineryDto.ToWineryFromCreateDTO();
            await _context.Wineries.AddAsync(wineryModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWineryById), new { id = wineryModel.Id }, wineryModel.ToWineryDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateWinery([FromRoute] int id, UpdateWineryRequestDto updateDto)
        {
            var wineryModel = await _context.Wineries.FirstOrDefaultAsync(x => x.Id == id);
            if(wineryModel == null)
            {
                return NotFound();
            }

            wineryModel.Name = updateDto.Name;
            wineryModel.Region = updateDto.Region;
            wineryModel.Country = updateDto.Country;
            wineryModel.EstablishedYear = updateDto.EstablishedYear;

            await _context.SaveChangesAsync();
            return Ok(wineryModel.ToWineryDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteWinery([FromRoute] int id)
        {
            var wineryModel = await _context.Wineries.FirstOrDefaultAsync(x => x.Id == id);
            if(wineryModel == null)
            {
                return NotFound();
            }

            _context.Wineries.Remove(wineryModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
