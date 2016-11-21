namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "StudentId", c => c.Int(identity: true, nullable: false));
            AlterColumn("dbo.Students", "IndexNo", c => c.String(nullable: false, maxLength: 15));
            AddPrimaryKey("dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "IndexNo", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.Students", "IndexNo");
        }
    }
}
