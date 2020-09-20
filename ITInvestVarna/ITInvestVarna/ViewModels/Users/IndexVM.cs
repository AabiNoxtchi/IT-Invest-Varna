using DataAccess.Entity;
using ITInvestVarna.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITInvestVarna.ViewModels.Users
{
    public class IndexVM : BaseIndexVM<User, FilterVM, OrderBy>
    {
    }
}