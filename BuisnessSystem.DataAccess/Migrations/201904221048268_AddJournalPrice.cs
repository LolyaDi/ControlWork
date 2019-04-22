namespace BuisnessSystem.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJournalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Journals", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Journals", "Price");
        }
    }
}
