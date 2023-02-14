namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Option : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TodoTimelines", newName: "TodoTimeline");
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
            DropIndex("dbo.Option", new[] { "EntityGuid" });
            DropTable("dbo.Option");
            RenameTable(name: "dbo.TodoTimeline", newName: "TodoTimelines");
        }
    }
}
