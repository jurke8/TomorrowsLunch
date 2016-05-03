﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomorrowsLunch.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        bool Deleted { get; set; }
        DateTime DateCreated { get; set; }
    }
}