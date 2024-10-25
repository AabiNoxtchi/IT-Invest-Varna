﻿using ITInvestVarna.Attributes.FilterVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ITInvestVarna.ViewModels.Shared
{
   
        public interface IFilterVM
        {
            string Prefix { get; set; }
        }

        public abstract class BaseFilterVM<E> : IFilterVM
        {
            [Skip]
            public string Prefix { get; set; }

            public abstract Expression<Func<E, bool>> GenerateFilter();
        }
   
}