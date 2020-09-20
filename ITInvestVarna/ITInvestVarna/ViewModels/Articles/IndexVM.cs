using DataAccess.Entity;
using ITInvestVarna.ViewModels.Articles;
using ITInvestVarna.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITInvestVarna.ViewModels.Articles
{
   
        public class IndexVM : BaseIndexVM<Article, FilterVM, OrderBy>
        {
        // public Comments.IndexVM CommentsIndexVM { get; set; }
        public List<User> Users { get; set; }

    }
   
}