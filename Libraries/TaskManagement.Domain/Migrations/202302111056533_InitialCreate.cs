namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                "dbo.UserTodo",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        TodoId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                        Todo_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.TodoId })
                .ForeignKey("dbo.Todo", t => t.TodoId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Todo", t => t.Todo_Id)
                .Index(t => t.UserId)
                .Index(t => t.TodoId)
                .Index(t => t.User_Id)
                .Index(t => t.Todo_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTodo", "Todo_Id", "dbo.Todo");
            DropForeignKey("dbo.UserTodo", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTodo", "User_Id", "dbo.User");
            DropForeignKey("dbo.UserTodo", "TodoId", "dbo.Todo");
            DropIndex("dbo.User", new[] { "EntityGuid" });
            DropIndex("dbo.UserTodo", new[] { "Todo_Id" });
            DropIndex("dbo.UserTodo", new[] { "User_Id" });
            DropIndex("dbo.UserTodo", new[] { "TodoId" });
            DropIndex("dbo.UserTodo", new[] { "UserId" });
            DropIndex("dbo.Todo", new[] { "EntityGuid" });
            DropTable("dbo.User");
            DropTable("dbo.UserTodo");
            DropTable("dbo.Todo");
        }
    }
}
