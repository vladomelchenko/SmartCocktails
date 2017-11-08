using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCocktails.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Club> Clubs { get; set; }
        public virtual IEnumerable<ApplicationUser> Users { get; set; }
    }
}