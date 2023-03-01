namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Parent_Option_Int : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Option", "ParentOptionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Option", "ParentOptionId");
        }
    }
}
