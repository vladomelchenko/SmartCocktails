namespace SmartCocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ewq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Constituents", "Cocktail_Id", c => c.Int());
            CreateIndex("dbo.Constituents", "Cocktail_Id");
            AddForeignKey("dbo.Constituents", "Cocktail_Id", "dbo.Cocktails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Constituents", "Cocktail_Id", "dbo.Cocktails");
            DropIndex("dbo.Constituents", new[] { "Cocktail_Id" });
            DropColumn("dbo.Constituents", "Cocktail_Id");
        }
    }
}
