using System.ComponentModel.DataAnnotations;

namespace EmotionApi.Features.Quotes.Models
{
    public class QuoteRequestModel
    {
      [Required]
      [MaxLength(5)]
      public string Lang { get; set; }
      public int MoodId { get; set; }

      public int CountryId { get; set; }
    }
}
