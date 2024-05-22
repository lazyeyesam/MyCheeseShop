using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;

namespace MyCheeseShop.Model
{
    public class Cheese
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Strength { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        [JsonIgnore]
        public List<Rating> Ratings { get; set; } = [];
    }
}
