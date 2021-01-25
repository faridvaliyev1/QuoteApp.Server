using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionApi.Data.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author author { get; set; }

        public int MoodId { get; set; }

        [ForeignKey("MoodId")]
        public virtual Mood mood { get; set; }
    }
}
