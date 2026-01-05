using Microsoft.AspNetCore.Mvc;
using WinellyApi.Data;
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
            var wineries = _context.Wineries.ToList()
                .Select(winery => winery.ToWineryDto());
            return Ok(wineries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWineryById(int id)
        {
            var winery = _context.Wineries.Find(id);
            if (winery == null)
            {
                return NotFound();
            }
            return Ok(winery.ToWineryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWineryRequestDto wineryDto)
        {
            var wineryModel = wineryDto.ToWineryFromCreateDTO();
            _context.Wineries.Add(wineryModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWineryById), new { id = wineryModel.Id }, wineryModel.ToWineryDto());
        }
    }
}
