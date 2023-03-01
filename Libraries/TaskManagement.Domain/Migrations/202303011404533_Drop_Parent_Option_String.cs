namespace TaskManagement.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drop_Parent_Option_String : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Option", "ParentOptionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Option", "ParentOptionId", c => c.String());
        }
    }
}
