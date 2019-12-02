namespace EventPlannerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventContactNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "ContactId", "dbo.Contacts");
            AddForeignKey("dbo.Events", "ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ContactId", "dbo.Contacts");
            AddForeignKey("dbo.Events", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
    }
}
