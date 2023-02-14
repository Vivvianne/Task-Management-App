namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDefaultIdParameter_UserTodo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserTodo", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTodo", "Id", c => c.Int(nullable: false));
        }
    }
}
