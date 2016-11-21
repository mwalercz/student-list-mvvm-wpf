namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "Group_GroupId", newName: "GroupId");
            RenameIndex(table: "dbo.Students", name: "IX_Group_GroupId", newName: "IX_GroupId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_GroupId", newName: "IX_Group_GroupId");
            RenameColumn(table: "dbo.Students", name: "GroupId", newName: "Group_GroupId");
        }
    }
}
