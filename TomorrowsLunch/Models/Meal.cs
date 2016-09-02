using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class Meal : BaseEntity
    {
        public virtual ICollection<MealIngredientQuantity> MealIngredientQuantites { get; set; }
        public virtual ICollection<Calendar> Calendars { get; set; }

        public Guid CreatedByUser { get; set; }
        public Meal()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            MealIngredientQuantites = new HashSet<MealIngredientQuantity>();
            Calendars = new HashSet<Calendar>();
        }
    }

}