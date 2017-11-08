using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCocktails.Models.ViewModel
{
    public class CocktailViewModel
    {
        public int Id { get; set; }
        public string CocktailName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public virtual IEnumerable<CocktailsConstituent> CocktailsConstituents { get; set; }
    }
}