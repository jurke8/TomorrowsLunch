using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public class User : BaseEntity
    {
        public string Password { get; set; }
        public User()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
    
}