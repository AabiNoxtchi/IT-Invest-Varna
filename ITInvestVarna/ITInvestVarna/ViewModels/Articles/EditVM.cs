using DataAccess.Entity;
using ITInvestVarna.Attributes.FilterVM;
using ITInvestVarna.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITInvestVarna.ViewModels.Articles
{
    public class EditVM : BaseEditVM<Article>
    {

        [DisplayName("Title")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Title { get; set; }


        [DisplayName("Text")]
        [Required(ErrorMessage = "This field is Required!")]        
        public string Text { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Type { get; set; }
       

        public int UserId { get; set; }


        [DropDownFilter(TargetModelProperty = "CategoryId", DataProperty = "Value", DisplayProperty = "Text")]
        public SelectList CategoriesList { get; set; } 

        [DisplayName("Category")]
        public int CategoryId { get; set; }


        public override void PopulateEntity(Article item)
        {
            item.Id = Id;
            item.Title = Title;
            item.Text = Text;
            item.Type = Type;
            item.UserId = UserId;
            item.CategoryId = CategoryId;
           
        }

        public override void PopulateModel(Article item)
        {
            Id = item.Id;
           Title = item.Title;
           Text = item.Text;
            Type = item.Type;
            UserId = item.UserId;
            CategoryId = item.CategoryId;
           
        }
    }
}