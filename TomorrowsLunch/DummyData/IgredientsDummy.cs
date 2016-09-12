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
                Name="mlijeko (0.9% masti)",
                Calories=50,
                Carbohydrates =5,
                Proteins = 3,
                Fat = 1
            },
            new Ingredient {
                Name="mlijeko (3.2% masti)",
                Calories=66,
                Carbohydrates =5,
                Proteins = 3,
                Fat = 3
            },
            new Ingredient {
                Name="jogurt (2.8% masti)",
                Calories=53,
                Carbohydrates =4,
                Proteins = 3,
                Fat = 3
            },
            new Ingredient {
                Name="grčki jogurt",
                Calories=125,
                Carbohydrates =6,
                Proteins = 4,
                Fat = 10
            },
            new Ingredient {
                Name="kefir",
                Calories=60,
                Carbohydrates =3,
                Proteins = 3,
                Fat = 4
            },
            new Ingredient {
                Name="parmezan",
                Calories=411,
                Carbohydrates =2,
                Proteins = 40,
                Fat = 27
            },
            new Ingredient {
                Name="posni sir",
                Calories=70,
                Carbohydrates =2,
                Proteins = 13,
                Fat = 2
            },
            new Ingredient {
                Name="sir Gouda",
                Calories=357,
                Carbohydrates = 0,
                Proteins = 26,
                Fat = 28
            },
            new Ingredient {
                Name="jaje",
                Calories=147,
                Carbohydrates =1,
                Proteins = 12,
                Fat = 10
            },
            new Ingredient {
                Name="rajčica",
                Calories=18,
                Carbohydrates = 4,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="badem",
                Calories=579,
                Carbohydrates = 21,
                Proteins = 21,
                Fat = 50
            },
            new Ingredient {
                Name="banana",
                Calories=89,
                Carbohydrates =23,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="limun",
                Calories=29,
                Carbohydrates = 9,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="grožđe",
                Calories=60,
                Carbohydrates =15,
                Proteins = 0,
                Fat = 0
            },
            new Ingredient {
                Name="jabuka",
                Calories=50,
                Carbohydrates =13,
                Proteins = 0,
                Fat = 0
            },
            new Ingredient {
                Name="kruška",
                Calories=58,
                Carbohydrates =15,
                Proteins = 0,
                Fat = 0
            },
            new Ingredient {
                Name="mandarina",
                Calories=34,
                Carbohydrates =8,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="naranča",
                Calories=47,
                Carbohydrates =12,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="orah",
                Calories=700,
                Carbohydrates =10,
                Proteins = 20,
                Fat = 60
            },
            new Ingredient {
                Name="zelena salata",
                Calories=13,
                Carbohydrates =2,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="cikla",
                Calories=36,
                Carbohydrates =7,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="grašak",
                Calories=78,
                Carbohydrates =14,
                Proteins = 5,
                Fat = 0
            },
            new Ingredient {
                Name="kikiriki",
                Calories=580,
                Carbohydrates =22,
                Proteins = 24,
                Fat = 50
            },
            new Ingredient {
                Name="kiseli krastavac",
                Calories=10,
                Carbohydrates =2,
                Proteins = 0,
                Fat = 0
            },
            new Ingredient {
                Name="svježi krastavac",
                Calories=14,
                Carbohydrates =2,
                Proteins = 0,
                Fat = 0
            },
            new Ingredient {
                Name="pečeni krumpir (bez soli)",
                Calories=93,
                Carbohydrates =21,
                Proteins = 2,
                Fat = 0
            },
            new Ingredient {
                Name="kuhani krupmir",
                Calories=90,
                Carbohydrates =21,
                Proteins = 2,
                Fat = 0
            },
            new Ingredient {
                Name="kukuruz",
                Calories=81,
                Carbohydrates =19,
                Proteins = 3,
                Fat = 1
            },
            new Ingredient {
                Name="kupus",
                Calories= 20,
                Carbohydrates =4,
                Proteins = 2,
                Fat = 0
            },
            new Ingredient {
                Name="bijeli luk",
                Calories=136,
                Carbohydrates =28,
                Proteins = 6,
                Fat = 0
            },
            new Ingredient {
                Name="crveni luk",
                Calories=24,
                Carbohydrates =5,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="mladi luk",
                Calories=35,
                Carbohydrates =9,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="mrkva",
                Calories=36,
                Carbohydrates = 8,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="zelena paprika",
                Calories=16,
                Carbohydrates = 3,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="crvena paprika",
                Calories=36,
                Carbohydrates = 6,
                Proteins = 1,
                Fat = 0
            },
            new Ingredient {
                Name="špinat",
                Calories=23,
                Carbohydrates = 4,
                Proteins = 3,
                Fat = 0
            },
            new Ingredient {
                Name="maslinovo ulje",
                Calories=884,
                Carbohydrates =0,
                Proteins = 0,
                Fat = 100
            },
            new Ingredient {
                Name="suncokretovo ulje",
                Calories=900,
                Carbohydrates = 0,
                Proteins = 0,
                Fat = 100
            },
            new Ingredient {
                Name="bijeli kruh",
                Calories= 234,
                Carbohydrates = 46,
                Proteins = 8,
                Fat = 2
            },
            new Ingredient {
                Name="brašno (bijelo)",
                Calories=350,
                Carbohydrates = 80,
                Proteins = 10,
                Fat = 1
            },
            new Ingredient {
                Name="tuna",
                Calories=140,
                Carbohydrates = 0,
                Proteins = 30,
                Fat = 3
            },
            new Ingredient {
                Name="lignja",
                Calories=77,
                Carbohydrates = 1,
                Proteins = 16,
                Fat = 1
            },
            new Ingredient {
                Name="oslić",
                Calories= 71,
                Carbohydrates = 0,
                Proteins = 17,
                Fat = 0
            },
             new Ingredient {
                Name="smuđ",
                Calories= 93,
                Carbohydrates = 0,
                Proteins = 19,
                Fat = 1
            },
              new Ingredient {
                Name="som",
                Calories= 95,
                Carbohydrates = 0,
                Proteins = 16,
                Fat = 3
            },
               new Ingredient {
                Name="šaran",
                Calories= 121,
                Carbohydrates = 1,
                Proteins = 16,
                Fat = 7
            },
            new Ingredient {
                Name="štuka",
                Calories= 85,
                Carbohydrates = 0,
                Proteins = 17,
                Fat = 2
            },
            new Ingredient {
                Name="pršut",
                Calories= 252,
                Carbohydrates = 0,
                Proteins = 30,
                Fat = 14
            },
            new Ingredient {
                Name="janjetina",
                Calories= 211,
                Carbohydrates = 0,
                Proteins = 19,
                Fat = 15
            },
            new Ingredient {
                Name="kobasica",
                Calories= 401,
                Carbohydrates = 3,
                Proteins = 14,
                Fat = 37
            },
            new Ingredient {
                Name="kulen",
                Calories= 450,
                Carbohydrates = 5,
                Proteins = 24,
                Fat = 37
            },
            new Ingredient {
                Name="piletina",
                Calories= 230,
                Carbohydrates = 0,
                Proteins = 18,
                Fat = 18
            },
            new Ingredient {
                Name="svinjetina",
                Calories= 280,
                Carbohydrates = 0,
                Proteins = 16,
                Fat = 24
            },
            new Ingredient {
                Name="šunka",
                Calories= 400,
                Carbohydrates = 0,
                Proteins = 22,
                Fat = 38
            },
            new Ingredient {
                Name="ćevapi",
                Calories= 230,
                Carbohydrates = 3,
                Proteins = 20,
                Fat = 16
            },
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