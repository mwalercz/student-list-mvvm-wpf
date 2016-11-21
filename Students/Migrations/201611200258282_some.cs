namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class some : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "Name", c => c.String(maxLength: 15));
            CreateIndex("dbo.Groups", "Name", unique: true, name: "IX_StudentIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Groups", "IX_StudentIndex");
            AlterColumn("dbo.Groups", "Name", c => c.String());
        }
    }
}
