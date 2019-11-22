namespace EventPlannerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventInheritanceFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "EventType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventType", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
