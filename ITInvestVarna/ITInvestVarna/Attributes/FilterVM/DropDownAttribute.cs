using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITInvestVarna.Attributes.FilterVM
{
    public class DropDownFilter : Attribute
    {
        public string DataProperty { get; set; }
        public string DisplayProperty { get; set; }
        public string TargetModelProperty { get; set; }
    }
}