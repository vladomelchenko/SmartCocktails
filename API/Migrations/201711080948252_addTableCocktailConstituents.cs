namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableCocktailConstituents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CocktailConstituents", "Cocktail_Id", "dbo.Cocktails");
            DropForeignKey("dbo.CocktailConstituents", "Constituent_Id", "dbo.Constituents");
            DropIndex("dbo.CocktailConstituents", new[] { "Cocktail_Id" });
            DropIndex("dbo.CocktailConstituents", new[] { "Constituent_Id" });
            CreateTable(
                "dbo.CocktailConstituetns",
                c => new
                    {
                        CocktailId = c.Int(nullable: false),
                        ConstituentId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CocktailId, t.ConstituentId })
                .ForeignKey("dbo.Cocktails", t => t.CocktailId, cascadeDelete: true)
                .ForeignKey("dbo.Constituents", t => t.ConstituentId, cascadeDelete: true)
                .Index(t => t.CocktailId)
                .Index(t => t.ConstituentId);
            
            DropColumn("dbo.Constituents", "Amount");
            DropTable("dbo.CocktailConstituents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CocktailConstituents",
                c => new
                    {
                        Cocktail_Id = c.Int(nullable: false),
                        Constituent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cocktail_Id, t.Constituent_Id });
            
            AddColumn("dbo.Constituents", "Amount", c => c.Double(nullable: false));
            DropForeignKey("dbo.CocktailConstituetns", "ConstituentId", "dbo.Constituents");
            DropForeignKey("dbo.CocktailConstituetns", "CocktailId", "dbo.Cocktails");
            DropIndex("dbo.CocktailConstituetns", new[] { "ConstituentId" });
            DropIndex("dbo.CocktailConstituetns", new[] { "CocktailId" });
            DropTable("dbo.CocktailConstituetns");
            CreateIndex("dbo.CocktailConstituents", "Constituent_Id");
            CreateIndex("dbo.CocktailConstituents", "Cocktail_Id");
            AddForeignKey("dbo.CocktailConstituents", "Constituent_Id", "dbo.Constituents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CocktailConstituents", "Cocktail_Id", "dbo.Cocktails", "Id", cascadeDelete: true);
        }
    }
}
