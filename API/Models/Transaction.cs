using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Cocktail Cocktail { get; set; }
        public DateTime Date { get; set; }
    }
}