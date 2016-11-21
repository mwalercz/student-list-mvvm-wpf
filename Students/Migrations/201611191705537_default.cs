namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _default : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            DropColumn("dbo.Students", "Id");
            AddColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Students", "City", c => c.String());
            AddColumn("dbo.Students", "IndexNo", c => c.String());
            AddPrimaryKey("dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Students");
            DropColumn("dbo.Students", "IndexNo");
            DropColumn("dbo.Students", "City");
            DropColumn("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.Students", "Id");
        }
    }
}
