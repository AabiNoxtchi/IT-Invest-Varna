using DataAccess.Entity;
using ITInvestVarna.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITInvestVarna.ViewModels.Articles
{

    public class OrderBy : BaseOrderBy<Article>
    {
        public string Title { get; set; }

        public string UserName { get; set; }

        public override Func<IQueryable<Article>, IOrderedQueryable<Article>> orderBy()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                return u => u.OrderBy(i => i.Title);
            }
            else if(!string.IsNullOrEmpty(UserName))
            {
                return u => u.OrderBy(i => i.User.Name);
            }

            return null;
        }
    }
}