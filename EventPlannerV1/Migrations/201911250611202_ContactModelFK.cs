namespace EventPlannerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactModelFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Contacts", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.Contacts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "UserId");
            AddForeignKey("dbo.Contacts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            AlterColumn("dbo.Contacts", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Contacts", name: "UserId", newName: "User_UserId");
            CreateIndex("dbo.Contacts", "User_UserId");
            AddForeignKey("dbo.Contacts", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
