namespace EventPlannerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(nullable: false, maxLength: 50),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Recurr = c.Boolean(nullable: false),
                        EventNote = c.String(maxLength: 500),
                        UserId = c.Int(nullable: false),
                        Location = c.String(maxLength: 100),
                        ContactId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        TelNo = c.String(maxLength: 50),
                        Note = c.String(maxLength: 500),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserId", "dbo.Users");
            DropForeignKey("dbo.Events", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "ContactId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Contacts");
            DropTable("dbo.Events");
        }
    }
}
