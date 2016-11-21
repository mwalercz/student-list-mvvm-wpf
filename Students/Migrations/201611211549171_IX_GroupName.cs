namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_GroupName : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.Groups", name: "IX_StudentIndex", newName: "IX_GroupName");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Groups", name: "IX_GroupName", newName: "IX_StudentIndex");
        }
    }
}
