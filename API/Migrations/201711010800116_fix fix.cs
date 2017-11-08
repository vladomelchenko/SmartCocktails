namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixfix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CocktailConstituents", newName: "CocteilsConstituents");
            RenameColumn(table: "dbo.CocteilsConstituents", name: "Cocktail_Id", newName: "CocktailId");
            RenameColumn(table: "dbo.CocteilsConstituents", name: "Constituent_Id", newName: "ConstituentId");
            RenameIndex(table: "dbo.CocteilsConstituents", name: "IX_Cocktail_Id", newName: "IX_CocktailId");
            RenameIndex(table: "dbo.CocteilsConstituents", name: "IX_Constituent_Id", newName: "IX_ConstituentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CocteilsConstituents", name: "IX_ConstituentId", newName: "IX_Constituent_Id");
            RenameIndex(table: "dbo.CocteilsConstituents", name: "IX_CocktailId", newName: "IX_Cocktail_Id");
            RenameColumn(table: "dbo.CocteilsConstituents", name: "ConstituentId", newName: "Constituent_Id");
            RenameColumn(table: "dbo.CocteilsConstituents", name: "CocktailId", newName: "Cocktail_Id");
            RenameTable(name: "dbo.CocteilsConstituents", newName: "CocktailConstituents");
        }
    }
}
