namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixTransactions : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "Cocteil_Id", newName: "Cocktail_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Cocteil_Id", newName: "IX_Cocktail_Id");
            AddColumn("dbo.AspNetUsers", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Balance");
            RenameIndex(table: "dbo.Transactions", name: "IX_Cocktail_Id", newName: "IX_Cocteil_Id");
            RenameColumn(table: "dbo.Transactions", name: "Cocktail_Id", newName: "Cocteil_Id");
        }
    }
}
