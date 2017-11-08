using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartCocktails.Models
{
    public class CocktailsConstituent
    {
        [Key,Column(Order = 1)]
        public int CocktailId { get; set; }
        [Key, Column(Order = 2)]
        public int ConstituentId { get; set; }
        [ForeignKey("CocktailId")]
        public Cocktail Cocteil { get; set; }
        [ForeignKey("ConstituentId")]
        public Constituent Constituent { get; set; }
        public double Amount { get; set; }
    }
}