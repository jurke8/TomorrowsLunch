using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class Ingredient : BaseEntity
    {
        public virtual ICollection<Meal> Meals { get; set; }
        public Ingredient()
        {
            Id = Guid.NewGuid();
            Meals = new HashSet<Meal>();
        }
    }
}