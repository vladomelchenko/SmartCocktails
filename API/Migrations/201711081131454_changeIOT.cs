namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIOT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Iots", "City_Id", "dbo.Cities");
            DropIndex("dbo.Iots", new[] { "City_Id" });
            AddColumn("dbo.Iots", "Club_Id", c => c.Int());
            CreateIndex("dbo.Iots", "Club_Id");
            AddForeignKey("dbo.Iots", "Club_Id", "dbo.Clubs", "Id");
            DropColumn("dbo.Iots", "City_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Iots", "City_Id", c => c.Int());
            DropForeignKey("dbo.Iots", "Club_Id", "dbo.Clubs");
            DropIndex("dbo.Iots", new[] { "Club_Id" });
            DropColumn("dbo.Iots", "Club_Id");
            CreateIndex("dbo.Iots", "City_Id");
            AddForeignKey("dbo.Iots", "City_Id", "dbo.Cities", "Id");
        }
    }
}
