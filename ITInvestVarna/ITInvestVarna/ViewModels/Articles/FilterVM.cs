using DataAccess.Entity;
using ITInvestVarna.Attributes.FilterVM;
using ITInvestVarna.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ITInvestVarna.ViewModels.Articles
{
    public class FilterVM : BaseFilterVM<Article>
    {
        [Skip]
        public Nullable<int> UserId { get; set; }

        [DisplayName("Company")]
        [DropDownFilter(TargetModelProperty = "UserId", DataProperty = "Value", DisplayProperty = "Text")]
        public SelectList UsersesList { get; set; }

        [Skip]
        public string Title { get; set; }

        [DisplayName("Title")]
        [DropDownFilter(TargetModelProperty = "Title", DisplayProperty = "Text", DataProperty = "Value")]
        public SelectList NameList { get; set; }

        [Hidden]
        public string Type { get; set; }
       
        [DisplayName("Category")]
        [DropDownFilter(TargetModelProperty = "CategoryId", DisplayProperty = "Text", DataProperty = "Value")]
        public SelectList CategoryList { get; set; }

        [Skip]
        public Nullable<int> CategoryId { get; set; }

       


        public override Expression<Func<Article, bool>> GenerateFilter()
        {
            return i => (string.IsNullOrEmpty(Title) || i.Title == Title) &&
                       (Type == null || i.Type == Type) &&
                       (UserId == null || i.UserId == UserId) &&
                       (CategoryId == null || i.CategoryId == CategoryId);


        }


    }
}