namespace SmartCocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnewnew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities");
            DropIndex("dbo.AspNetUsers", new[] { "City_Id" });
            DropColumn("dbo.AspNetUsers", "City_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "City_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "City_Id");
            AddForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities", "Id");
        }
    }
}
