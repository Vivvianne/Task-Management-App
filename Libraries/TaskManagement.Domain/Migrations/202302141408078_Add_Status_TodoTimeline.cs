namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Status_TodoTimeline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoTimeline", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoTimeline", "Status");
        }
    }
}
