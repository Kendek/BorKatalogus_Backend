using Microsoft.AspNetCore.Mvc;
using WinellyApi.Data;

namespace WinellyApi.Controllers
{
    [Route("api/grape")]
    [ApiController]
    public class GrapeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GrapeController(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
