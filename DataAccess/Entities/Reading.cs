#nullable disable

using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Reading : Record
    {
        [Required]
        public string Explanation { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public List<TarotCard> TarotCard { get; set; }

        public List<UserReading> UserReadings { get; set; }
    }
}
