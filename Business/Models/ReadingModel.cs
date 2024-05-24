#nullable disable

using DataAccess.Entities;
using DataAccess.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class ReadingModel : Record
    {
        [Required]
        public string Explanation { get; set; }

        [DisplayName("Publish Date")]
        public DateTime? CreatedAt { get; set; }

        [DisplayName("Price")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} must be positive!")]
        public decimal? Price { get; set; }

        #region Extra Properties
        [DisplayName("Publish Date")]
        public string CreatedAtOutput { get; set; }

        [DisplayName("Price")]
        public string TotalSalesPriceOutput { get; set; }

        [DisplayName("Cards")]
        public List<TarotCardModel> TarotCards { get; set; }
        #endregion

    }
}
