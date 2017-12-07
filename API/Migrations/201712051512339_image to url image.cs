namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagetourlimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cocktails", "ImageUrl", c => c.String());
            DropColumn("dbo.Cocktails", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cocktails", "Image", c => c.Binary());
            DropColumn("dbo.Cocktails", "ImageUrl");
        }
    }
}
