﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCocktails.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
    }
}