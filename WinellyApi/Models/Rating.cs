using System.ComponentModel.DataAnnotations.Schema;

namespace WinellyApi.Models
{
    [Table("Ratings")]
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime ReviewDate { get; set; }
        public int WineryId { get; set; }
        public Winery Winery { get; set; }
    }
}
