using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCocktails.Models
{
    public class Cocktail
    {
        [Key]
        public int Id { get; set; }
        public string CocktailName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<CocktailsConstituent> CocktailsConstituents { get; set; }
    }
}