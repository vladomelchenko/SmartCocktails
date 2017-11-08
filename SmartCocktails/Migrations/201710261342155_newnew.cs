namespace SmartCocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cocktails", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cocktails", "Description");
        }
    }
}
