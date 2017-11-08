namespace SmartCocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Constituents", "Cocktail_Id", "dbo.Cocktails");
            DropIndex("dbo.Constituents", new[] { "Cocktail_Id" });
            DropColumn("dbo.Constituents", "Cocktail_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Constituents", "Cocktail_Id", c => c.Int());
            CreateIndex("dbo.Constituents", "Cocktail_Id");
            AddForeignKey("dbo.Constituents", "Cocktail_Id", "dbo.Cocktails", "Id");
        }
    }
}
