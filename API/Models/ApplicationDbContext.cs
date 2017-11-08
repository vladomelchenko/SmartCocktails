using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Constituent> Constituents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Iot> Iots { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<IotConstituent> IotConstituents { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CocktailConstituents> CocktailConstituetnses { get; set; }
    }
}