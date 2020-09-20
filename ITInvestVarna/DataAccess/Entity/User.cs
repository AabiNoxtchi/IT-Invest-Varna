using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity
{
    public class User:BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]       
        public string Email { get; set; }       

        [Required]
        public string Password { get; set; }     

        public bool IsAdmin { get; set; }

        public bool IsCompany { get; set; }

        public string ImgPath { get; set; }

        public string About { get; set; }

        public System.Guid ActivationCode { get; set; }

        public bool IsEmailVerified { get; set; }

        public  virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public virtual ICollection<SearchHistory> SearchHistories { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }




    }
}
