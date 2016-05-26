﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TomorrowsLunch.Models;

namespace TomorrowsLunch.DummyData
{
    public class UsersDummy
    {
        private static List<User> _instance = new List<User>(){
            new User {
                Name = "admin",
                Password = "adminadmin",
                Email = "admin@admin.com"
            }         
        };

        public static List<User> Data
        {
            get
            {
                return _instance;
            }
        }
    }
}