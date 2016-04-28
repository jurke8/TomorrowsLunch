﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class Meal : BaseEntity
    {
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public Meal()
        {
            Id = Guid.NewGuid();
            Ingredients = new HashSet<Ingredient>();
        }
    }
    
}