using ITInvestVarna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITInvestVarna.Filters
{
    public class AuthorizeAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedUser != null && !AuthenticationManager.LoggedUser.IsAdmin)
                filterContext.Result = new RedirectResult("/Home/Index");
        }
    }
}