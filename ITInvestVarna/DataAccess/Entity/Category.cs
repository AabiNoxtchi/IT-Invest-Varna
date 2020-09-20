﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Category:BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
