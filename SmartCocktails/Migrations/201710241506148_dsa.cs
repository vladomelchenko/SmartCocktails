namespace SmartCocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CocteilsConstituents",
                c => new
                    {
                        CocktailId = c.Int(nullable: false),
                        ConstituentId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.CocktailId, t.ConstituentId })
                .ForeignKey("dbo.Cocktails", t => t.CocktailId, cascadeDelete: true)
                .ForeignKey("dbo.Constituents", t => t.ConstituentId, cascadeDelete: true)
                .Index(t => t.CocktailId)
                .Index(t => t.ConstituentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CocteilsConstituents", "ConstituentId", "dbo.Constituents");
            DropForeignKey("dbo.CocteilsConstituents", "CocktailId", "dbo.Cocktails");
            DropIndex("dbo.CocteilsConstituents", new[] { "ConstituentId" });
            DropIndex("dbo.CocteilsConstituents", new[] { "CocktailId" });
            DropTable("dbo.CocteilsConstituents");
        }
    }
}
