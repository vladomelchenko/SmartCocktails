using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCocktails.Models
{
    public class Iot
    {
        public int Id { get; set; }
        public City City { get; set; }
        public virtual IEnumerable<Constituent> Constituents { get; set; }
        public virtual IEnumerable<Cocktail> Cocktails { get; set; }
    }
}