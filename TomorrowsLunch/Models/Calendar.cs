using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class Calendar : BaseEntity
    {
        public DateTime CalendarDate { get; set; }
        public string DayOfWeek { get; set; }
        public Guid CreatedByUser { get; set; }
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }

        public Calendar()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }

}