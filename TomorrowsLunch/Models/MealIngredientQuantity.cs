using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class MealIngredientQuantity : BaseEntity
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int IngredientCarbohydrates { get; set; }
        public int IngredientFat { get; set; }
        public int IngredientProteins { get; set; }
        public int IngredientCalories { get; set; }
        public Guid CreatedByUser { get; set; }
        public int Quantity { get; set; }
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }

        public MealIngredientQuantity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}