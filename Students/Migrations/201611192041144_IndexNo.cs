namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexNo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group_GroupId" });
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "IndexNo", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Students", "FirstName", c => c.String(maxLength: 32));
            AddColumn("dbo.Students", "LastName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Students", "Group_GroupId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", "IndexNo");
            CreateIndex("dbo.Students", "Group_GroupId");
            AddForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
            DropColumn("dbo.Students", "StudentId");
            DropColumn("dbo.Students", "Name");
            DropColumn("dbo.Students", "Surname");
            DropColumn("dbo.Students", "Index");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Index", c => c.String());
            AddColumn("dbo.Students", "Surname", c => c.String());
            AddColumn("dbo.Students", "Name", c => c.String());
            AddColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group_GroupId" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Group_GroupId", c => c.Int());
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "FirstName");
            DropColumn("dbo.Students", "IndexNo");
            AddPrimaryKey("dbo.Students", "StudentId");
            CreateIndex("dbo.Students", "Group_GroupId");
            AddForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups", "GroupId");
        }
    }
}
