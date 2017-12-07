using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Cocktail
    {
        [Key]
        public int Id { get; set; }
        public string CocktailName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<CocktailConstituents> CocktailConstituents { get; set; }
    }
}