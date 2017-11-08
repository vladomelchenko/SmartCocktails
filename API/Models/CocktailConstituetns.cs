using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class CocktailConstituents
    {
        [Key, Column(Order = 1)]
        public int CocktailId { get; set; }
        [Key, Column(Order = 2)]
        public int ConstituentId { get; set; }
        [ForeignKey("CocktailId")]
        public Cocktail Cocktail { get; set; }
        [ForeignKey("ConstituentId")]
        public Constituent Constituent { get; set; }
        public int Amount { get; set; }
    }
}