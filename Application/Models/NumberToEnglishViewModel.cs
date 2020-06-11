using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class NumberToEnglishViewModel
    {
        [Required]
        [Range(-999999999999, 999999999999)]
        public decimal? Number { get; set; }
    }
}