using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Constituent
    {
        [Key]
        public int Id { get; set; }
        public string ConstituentsName { get; set; }
        public ICollection<CocktailConstituents> CocktailConstituents { get; set; }
    }
}