using EmotionApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catstagram.Server.Data.Models
{
    public class User:IdentityUser
    {
        public int QuoteId { get; set; }

        [ForeignKey("QuoteId")]
        public virtual List<Quote> quotes { get; set; }
    }
}
