namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_TodoTimeline : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoTimelines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UserTodoGuid = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserTodoGuid);
            
            AddColumn("dbo.UserTodo", "EntityGuid", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserTodo", "EntityGuid", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.TodoTimelines", new[] { "UserTodoGuid" });
            DropIndex("dbo.UserTodo", new[] { "EntityGuid" });
            DropColumn("dbo.UserTodo", "EntityGuid");
            DropTable("dbo.TodoTimelines");
        }
    }
}
