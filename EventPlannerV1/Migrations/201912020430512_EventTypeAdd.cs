namespace EventPlannerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTypeAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventType", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventType");
        }
    }
}
