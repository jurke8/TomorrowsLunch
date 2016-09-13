using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TomorrowsLunch.Repositories;

namespace TomorrowsLunch.Models
{

    public class Meal : BaseEntity
    {
        public virtual ICollection<MealIngredientQuantity> MealIngredientQuantites { get; set; }
        public virtual ICollection<Calendar> Calendars { get; set; }
        public string Recipe { get; set; }
        [NotMapped]
        public int Calories
        {
            get
            {
                var calories = 0;
                foreach (var item in MealIngredientQuantites)
                {
                    calories += (item.Quantity * item.IngredientCalories) / 100;
                }
                return calories;
            }
            set
            {
            }
        }
        [NotMapped]
        public int Carbohydrates
        {
            get
            {
                var carbohydrates = 0;
                foreach (var item in MealIngredientQuantites)
                {
                    carbohydrates += (item.Quantity * item.IngredientCarbohydrates) / 100;
                }
                return carbohydrates;
            }
        }
        [NotMapped]
        public int Fat
        {
            get
            {
                var fat = 0;
                foreach (var item in MealIngredientQuantites)
                {
                    fat += (item.Quantity * item.IngredientFat) / 100;
                }
                return fat;
            }
        }
        [NotMapped]
        public int Proteins
        {
            get
            {
                var proteins = 0;
                foreach (var item in MealIngredientQuantites)
                {
                    proteins += (item.Quantity * item.IngredientProteins) / 100;
                }
                return proteins;
            }
        }

        public Guid CreatedByUser { get; set; }
        public Meal()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            MealIngredientQuantites = new HashSet<MealIngredientQuantity>();
            Calendars = new HashSet<Calendar>();
        }
        private List<Ingredient> getIngredients()
        {
            var ir = new IngredientRepository();
            var allIngredients = ir.GetAll(CreatedByUser);
            var ingredients = new List<Ingredient>();

            foreach (var item in MealIngredientQuantites)
            {
                ingredients.Add(allIngredients.Where(i => i.Id.Equals(item.IngredientId)).First());
            }
            return ingredients;
        }
    }

}