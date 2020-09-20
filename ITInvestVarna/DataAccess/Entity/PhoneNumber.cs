using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class PhoneNumber:BaseEntity
    {

        public int? UserId { get; set; }

        public int? AddressId { get; set; }

        [MaxLength(10)]
        public string Phone_Number { get; set; }

        public virtual User User { get; set; }

        public virtual Address Address { get; set; }
    }
}
