#nullable disable

using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class TarotCard : Record
    {
        [Required]
        public string CardName { get; set; }
        public int ReadingId { get; set; }
        public Reading Reading {  get; set; }
    }
}
