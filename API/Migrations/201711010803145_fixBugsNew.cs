namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixBugsNew : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CocktailsConstituents", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.CocteilsConstituents", newName: "CocktailsConstituents");
            RenameTable(name: "__mig_tmp__0", newName: "CocktailsConstituents1");
        }
        
        public override void Down()
        {
            RenameTable(name: "CocktailsConstituents1", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.CocktailsConstituents", newName: "CocteilsConstituents");
            RenameTable(name: "dbo.__mig_tmp__0", newName: "CocktailsConstituents");
        }
    }
}
