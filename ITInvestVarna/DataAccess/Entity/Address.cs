using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Address:BaseEntity
    {
        public int UserId { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(250)]
        public string Street { get; set; }

        [MaxLength(5)]
        public string Number { get; set; }

        public User User { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
