namespace BuisnessSystem.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Journals", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Journals", new[] { "Client_Id" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDelivered = c.Boolean(nullable: false),
                        Client_Id = c.Guid(),
                        Journal_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Journals", t => t.Journal_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Journal_Id);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Journals", "Client_Id", c => c.Guid());
            DropForeignKey("dbo.Orders", "Journal_Id", "dbo.Journals");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Journal_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropTable("dbo.Orders");
            AddForeignKey("dbo.Journals", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
