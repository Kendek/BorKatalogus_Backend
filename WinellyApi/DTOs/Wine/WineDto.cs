using WinellyApi.Models;

namespace WinellyApi.DTOs.Wine
{
    public class WineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public double AlcoholContent { get; set; }
        public int WineryId { get; set; }
    }
}
