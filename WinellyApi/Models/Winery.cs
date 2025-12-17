using System.ComponentModel.DataAnnotations.Schema;

namespace WinellyApi.Models
{
    [Table("Wineries")]
    public class Winery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Region { get; set; }
        public string Country { get; set; }
        public int EstablishedYear { get; set; }
        public List<Wine> Wines { get; set; } = new();
    }
}
