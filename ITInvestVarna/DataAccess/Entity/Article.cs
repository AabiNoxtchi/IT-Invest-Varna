using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Article:BaseEntity
    {
        public DateTime DateTime { get; set; }

        public DateTime? DateTimeModified { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }  

        public DateTime? StartDateTime { get; set; }
        
        public DateTime? EndDateTime { get; set; }

        public string Location { get; set; }

        public string ImgPath { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }       

        public virtual User User { get; set; }

        public Category category { get; set; }

        public ICollection<KeyWord> KeyWords { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Gallery> Galleries { get; set; }

        public virtual ICollection<SearchHistory> SearchHistories { get; set; }
    }
}
