using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class MealIngredientQuantity : BaseEntity
    {
        public Guid MealId { get; set; }
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
        public Guid CreatedByUser { get; set; }
        public decimal Quantity { get; set; }
        public virtual Meal Meal { get; set; }

        public MealIngredientQuantity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}