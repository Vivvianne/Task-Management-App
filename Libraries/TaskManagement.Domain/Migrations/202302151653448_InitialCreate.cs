namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityGuid = c.Guid(nullable: false),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EntityGuid, unique: true);
            
            CreateTable(
                "dbo.UserTodo",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        TodoId = c.Int(nullable: false),
                        EntityGuid = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.TodoId })
                .ForeignKey("dbo.Todo", t => t.TodoId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TodoId)
                .Index(t => t.EntityGuid, unique: true);
            
            CreateTable(
                "dbo.Todo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityGuid = c.Guid(nullable: false),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EntityGuid, unique: true);
            
            CreateTable(
                "dbo.TodoTimeline",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Status = c.String(),
                        UserTodoGuid = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserTodoGuid);
            
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityGuid = c.Guid(nullable: false),
                        Label = c.String(),
                        ParentOptionId = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EntityGuid, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTodo", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTodo", "TodoId", "dbo.Todo");
            DropIndex("dbo.Option", new[] { "EntityGuid" });
            DropIndex("dbo.TodoTimeline", new[] { "UserTodoGuid" });
            DropIndex("dbo.Todo", new[] { "EntityGuid" });
            DropIndex("dbo.UserTodo", new[] { "EntityGuid" });
            DropIndex("dbo.UserTodo", new[] { "TodoId" });
            DropIndex("dbo.UserTodo", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "EntityGuid" });
            DropTable("dbo.Option");
            DropTable("dbo.TodoTimeline");
            DropTable("dbo.Todo");
            DropTable("dbo.UserTodo");
            DropTable("dbo.User");
        }
    }
}
