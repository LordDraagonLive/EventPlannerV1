namespace EventPlannerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventPlanner : DbMigration
    {
        public override void Up()
        {
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
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(nullable: false, maxLength: 50),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        EventType = c.String(nullable: false, maxLength: 50),
                        Recurr = c.Boolean(nullable: false),
                        EventNote = c.String(maxLength: 500),
                        Location = c.String(maxLength: 100),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        User_UserId = c.Int(),
                        Contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId)
                .Index(t => t.User_UserId)
                .Index(t => t.Contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Events", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Contacts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "Contact_ContactId" });
            DropIndex("dbo.Events", new[] { "User_UserId" });
            DropIndex("dbo.Contacts", new[] { "User_UserId" });
            DropTable("dbo.Events");
            DropTable("dbo.Contacts");
        }
    }
}
