using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class Ingredient : BaseEntity
    {
        //public virtual ICollection<Meal> Meals { get; set; }
        public Guid CreatedByUser { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }
        public int Proteins { get; set; }
        public int Calories { get; set; }
        [NotMapped]
        public int Group { get; set; }

        public Ingredient()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            //Meals = new HashSet<Meal>();
        }
    }
}