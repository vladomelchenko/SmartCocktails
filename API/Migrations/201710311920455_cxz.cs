namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cxz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CocktailConstituents",
                c => new
                    {
                        Cocktail_Id = c.Int(nullable: false),
                        Constituent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cocktail_Id, t.Constituent_Id })
                .ForeignKey("dbo.Cocktails", t => t.Cocktail_Id, cascadeDelete: true)
                .ForeignKey("dbo.Constituents", t => t.Constituent_Id, cascadeDelete: true)
                .Index(t => t.Cocktail_Id)
                .Index(t => t.Constituent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CocktailConstituents", "Constituent_Id", "dbo.Constituents");
            DropForeignKey("dbo.CocktailConstituents", "Cocktail_Id", "dbo.Cocktails");
            DropIndex("dbo.CocktailConstituents", new[] { "Constituent_Id" });
            DropIndex("dbo.CocktailConstituents", new[] { "Cocktail_Id" });
            DropTable("dbo.CocktailConstituents");
        }
    }
}
