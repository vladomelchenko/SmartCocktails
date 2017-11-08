namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameFields : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CocktailConstituetns", newName: "CocktailConstituents");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CocktailConstituents", newName: "CocktailConstituetns");
        }
    }
}
