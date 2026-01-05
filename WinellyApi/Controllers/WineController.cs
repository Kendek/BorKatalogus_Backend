using Microsoft.AspNetCore.Mvc;
using WinellyApi.Data;
using WinellyApi.DTOs.Wine;
using WinellyApi.Mappers;

namespace WinellyApi.Controllers
{
    [Route("api/wine")]
    [ApiController]
    public class WineController : ControllerBase
    {
       private  readonly ApplicationDbContext _context;
        public WineController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetWines()
        {
            var wines = _context.Wines.ToList()
                .Select(wine => wine.ToWineDto());
            return Ok(wines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWineById(int id)
        {
            var wine = _context.Wines.Find(id);
            if (wine == null)
            {
                return NotFound();
            }
            return Ok(wine.ToWineDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWineRequestDto wineDto)
        {
            var winery = await _context.Wineries.FindAsync(wineDto.WineryId);
            if (winery == null) return BadRequest("Invalid WineryId.");

            var wineModel = wineDto.ToWineFromCreateDTO();
            wineModel.Winery = winery;
            _context.Wines.Add(wineModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWineById), new { id = wineModel.Id }, wineModel.ToWineDto());
        }
    }
}
