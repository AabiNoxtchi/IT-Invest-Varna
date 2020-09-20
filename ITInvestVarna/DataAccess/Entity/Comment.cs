using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Comment:BaseEntity
    {
        public DateTime DateTime { get; set; }

        public DateTime? DateTimeModified { get; set; }

        public string Text { get; set; }

        public int? UserId { get; set; }

        public int ArticleId { get; set; }

        public virtual User User { get; set; }

        public Article Article { get; set; }

    }
}
