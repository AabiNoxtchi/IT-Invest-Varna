using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITInvestVarna.ViewModels.Users
{
    public class DetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public string Email { get; set; }

       
        public string Password { get; set; }

        public string ImgPath { get; set; }

        public string About { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsCompany { get; set; }

        public System.Guid ActivationCode { get; set; }

        public bool IsEmailVerified { get; set; }

        public List<Address> addresses  { get; set; }



        public void PopulateDetailModel(User item)
        {
            
            Name = item.Name;
            ImgPath = item.ImgPath;
            Email = item.Email;
            Password = item.Password;
            IsAdmin = item.IsAdmin;
            About = item.About;
            IsEmailVerified = item.IsEmailVerified;
            ActivationCode = item.ActivationCode;
            IsCompany = item.IsCompany;
        }
    }
}