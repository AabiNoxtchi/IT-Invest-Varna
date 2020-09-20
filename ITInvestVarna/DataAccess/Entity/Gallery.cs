using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Gallery:BaseEntity
    {
        public string ImgPath { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
