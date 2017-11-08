namespace SmartCocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CocteilsConstituents", newName: "CocktailsConstituents");
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Balance", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "City_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "City_Id");
            AddForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities");
            DropIndex("dbo.AspNetUsers", new[] { "City_Id" });
            DropColumn("dbo.AspNetUsers", "City_Id");
            DropColumn("dbo.AspNetUsers", "Balance");
            DropColumn("dbo.Transactions", "Date");
            DropTable("dbo.Cities");
            RenameTable(name: "dbo.CocktailsConstituents", newName: "CocteilsConstituents");
        }
    }
}
