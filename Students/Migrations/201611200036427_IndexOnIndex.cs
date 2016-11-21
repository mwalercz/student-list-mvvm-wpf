namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexOnIndex : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "IndexNo", c => c.String(maxLength: 15));
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "StudentId");
            CreateIndex("dbo.Students", "IndexNo", unique: true, name: "IX_StudentIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", "IX_StudentIndex");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "IndexNo", c => c.String(nullable: false, maxLength: 15));
            AddPrimaryKey("dbo.Students", "IndexNo");
        }
    }
}
