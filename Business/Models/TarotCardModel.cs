using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class TarotCardModel : Record
    {
        [Required]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string CardName { get; set; }
    }
}
