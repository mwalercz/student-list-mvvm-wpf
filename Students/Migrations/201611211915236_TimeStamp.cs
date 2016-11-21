namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeStamp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "RowVersion");
            AddColumn("dbo.Students", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "RowVersion", c => c.Binary());
        }
    }
}
