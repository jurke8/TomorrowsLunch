using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Activity { get; set; }
        [NotMapped]
        public string BMI
        {
            get
            {
                return (Weight / ((decimal)(Height * Height) / 10000)).ToString("#.##");
            }
            set
            {
            }
        }
        [NotMapped]
        public string BMR
        {
            get
            {
                if ("male".Equals(Gender))
                {
                    return (66.47 + 13.75 * Weight + 5 * Height - 6.75 * Age).ToString("#.##"); ;
                }
                else
                {
                    return (665.09 + 9.56 * Weight + 1.84 * Height - 4.67 * Age).ToString("#.##"); ;
                }
            }
            set
            {
            }
        }
        [NotMapped]
        public string CaloriesPerDay
        {
            get
            {
                switch (Activity)
                {
                    case 1: return (Convert.ToDouble(BMR) * 1.2).ToString("#.##"); ;
                    case 2: return (Convert.ToDouble(BMR) * 1.375).ToString("#.##"); ;
                    case 3: return (Convert.ToDouble(BMR) * 1.55).ToString("#.##"); ;
                    case 4: return (Convert.ToDouble(BMR) * 1.725).ToString("#.##"); ;
                    case 5: return (Convert.ToDouble(BMR) * 1.9).ToString("#.##"); ;

                    default:
                        return BMR;
                }
            }
            set
            {
            }
        }

        public User()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }

}