namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixfixfix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CocktailsConstituents", newName: "CocktailConstituents");
            DropForeignKey("dbo.CocktailsConstituents1", "CocktailId", "dbo.Cocktails");
            DropForeignKey("dbo.CocktailsConstituents1", "ConstituentId", "dbo.Constituents");
            DropIndex("dbo.CocktailsConstituents1", new[] { "CocktailId" });
            DropIndex("dbo.CocktailsConstituents1", new[] { "ConstituentId" });
            RenameColumn(table: "dbo.CocktailConstituents", name: "CocktailId", newName: "Cocktail_Id");
            RenameColumn(table: "dbo.CocktailConstituents", name: "ConstituentId", newName: "Constituent_Id");
            RenameIndex(table: "dbo.CocktailConstituents", name: "IX_CocktailId", newName: "IX_Cocktail_Id");
            RenameIndex(table: "dbo.CocktailConstituents", name: "IX_ConstituentId", newName: "IX_Constituent_Id");
            AddColumn("dbo.Constituents", "Amount", c => c.Double(nullable: false));
            DropTable("dbo.CocktailsConstituents1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CocktailsConstituents1",
                c => new
                    {
                        CocktailId = c.Int(nullable: false),
                        ConstituentId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.CocktailId, t.ConstituentId });
            
            DropColumn("dbo.Constituents", "Amount");
            RenameIndex(table: "dbo.CocktailConstituents", name: "IX_Constituent_Id", newName: "IX_ConstituentId");
            RenameIndex(table: "dbo.CocktailConstituents", name: "IX_Cocktail_Id", newName: "IX_CocktailId");
            RenameColumn(table: "dbo.CocktailConstituents", name: "Constituent_Id", newName: "ConstituentId");
            RenameColumn(table: "dbo.CocktailConstituents", name: "Cocktail_Id", newName: "CocktailId");
            CreateIndex("dbo.CocktailsConstituents1", "ConstituentId");
            CreateIndex("dbo.CocktailsConstituents1", "CocktailId");
            AddForeignKey("dbo.CocktailsConstituents1", "ConstituentId", "dbo.Constituents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CocktailsConstituents1", "CocktailId", "dbo.Cocktails", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.CocktailConstituents", newName: "CocktailsConstituents");
        }
    }
}
