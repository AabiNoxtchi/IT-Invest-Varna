using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Rating:BaseEntity
    {
      
        public int UserId { get; set; }        

        public virtual User User { get; set; }

        public int UserIdBeingRated { get; set; }

        public virtual User UserBeingRated { get; set; }

        public int RatingValue { get; set; }
    }
}
