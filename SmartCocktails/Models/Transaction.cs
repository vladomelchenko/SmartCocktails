using System;
using System.ComponentModel.DataAnnotations;

namespace SmartCocktails.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Cocktail Cocteil { get; set; }
        public DateTime Date { get; set; }
    }
}