using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TomorrowsLunch.Models;

namespace TomorrowsLunch.DummyData
{
    public class IngredientsDummy
    {
        private static List<Ingredient> _instance = new List<Ingredient>(){
            new Ingredient {
                Name="brasno"
            },
            new Ingredient {
                Name="sol"
            },
            new Ingredient {
                Name="papar"
            }            
        };

        public static List<Ingredient> Data
        {
            get
            {
                return _instance;
            }
        }
    }
}