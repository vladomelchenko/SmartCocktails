using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SmartCocktails.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Constituent> Constituents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CocktailsConstituent> CocteilsConstituents { get; set; }
        public DbSet<Iot> Iots { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<IotConstituent> IotConstituents { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}