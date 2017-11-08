namespace SmartCocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb26102017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.IotConstituents",
                c => new
                    {
                        IotId = c.Int(nullable: false),
                        ConstituentId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.IotId, t.ConstituentId })
                .ForeignKey("dbo.Constituents", t => t.ConstituentId, cascadeDelete: true)
                .ForeignKey("dbo.Iots", t => t.IotId, cascadeDelete: true)
                .Index(t => t.IotId)
                .Index(t => t.ConstituentId);
            
            CreateTable(
                "dbo.Iots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IotConstituents", "IotId", "dbo.Iots");
            DropForeignKey("dbo.Iots", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.IotConstituents", "ConstituentId", "dbo.Constituents");
            DropForeignKey("dbo.Clubs", "City_Id", "dbo.Cities");
            DropIndex("dbo.Iots", new[] { "City_Id" });
            DropIndex("dbo.IotConstituents", new[] { "ConstituentId" });
            DropIndex("dbo.IotConstituents", new[] { "IotId" });
            DropIndex("dbo.Clubs", new[] { "City_Id" });
            DropTable("dbo.Iots");
            DropTable("dbo.IotConstituents");
            DropTable("dbo.Clubs");
        }
    }
}
