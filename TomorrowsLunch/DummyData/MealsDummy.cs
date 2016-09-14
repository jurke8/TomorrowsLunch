using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TomorrowsLunch.Models;

namespace TomorrowsLunch.DummyData
{
    public class MealsDummy
    {
        private static List<Meal> _instance = new List<Meal>(){
        };

        public static List<Meal> Data
        {
            get
            {
                return _instance;
            }
        }
    }
}