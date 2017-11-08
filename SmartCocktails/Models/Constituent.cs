using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCocktails.Models
{
    public class Constituent
    {
        [Key]
        public int Id { get; set; }
        public string ConstituentsName { get; set; }
        public virtual IEnumerable<CocktailsConstituent> CocktailsConstituents { get; set; }
    }
}