namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldIntoClubs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clubs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clubs", "Description");
        }
    }
}
