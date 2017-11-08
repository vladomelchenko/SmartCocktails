namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIotConstituents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cocktails", "Iot_Id", c => c.Int());
            CreateIndex("dbo.Cocktails", "Iot_Id");
            AddForeignKey("dbo.Cocktails", "Iot_Id", "dbo.Iots", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cocktails", "Iot_Id", "dbo.Iots");
            DropIndex("dbo.Cocktails", new[] { "Iot_Id" });
            DropColumn("dbo.Cocktails", "Iot_Id");
        }
    }
}
