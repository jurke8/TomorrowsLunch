using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TomorrowsLunch.Models;

namespace TomorrowsLunch.DummyData
{
    public class MealIngredientQuantitiesDummy
    {
        private static List<MealIngredientQuantity> _instance = new List<MealIngredientQuantity>(){
            //new MealIngredientQuantity {

            //}
        };

        public static List<MealIngredientQuantity> Data
        {
            get
            {
                return _instance;
            }
        }
    }
}