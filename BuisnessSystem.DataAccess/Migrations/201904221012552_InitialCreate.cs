namespace BuisnessSystem.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Fullname = c.String(nullable: false, maxLength: 150),
                        TelephoneNumber = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TelephoneNumber, unique: true);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Client_Id = c.Guid(),
                        Publisher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        TelephoneNumber = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.TelephoneNumber, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Journals", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.Journals", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Publishers", new[] { "Email" });
            DropIndex("dbo.Publishers", new[] { "TelephoneNumber" });
            DropIndex("dbo.Publishers", new[] { "Name" });
            DropIndex("dbo.Journals", new[] { "Publisher_Id" });
            DropIndex("dbo.Journals", new[] { "Client_Id" });
            DropIndex("dbo.Journals", new[] { "Name" });
            DropIndex("dbo.Clients", new[] { "TelephoneNumber" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Journals");
            DropTable("dbo.Clients");
        }
    }
}
