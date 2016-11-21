namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", "IX_StudentIndex");
            AlterColumn("dbo.Students", "IndexNo", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("dbo.Students", "IndexNo", unique: true, name: "IX_StudentIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", "IX_StudentIndex");
            AlterColumn("dbo.Students", "LastName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Students", "IndexNo", c => c.String(maxLength: 15));
            CreateIndex("dbo.Students", "IndexNo", unique: true, name: "IX_StudentIndex");
        }
    }
}
