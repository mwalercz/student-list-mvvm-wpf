namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConcurencyToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "RowVersion", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "RowVersion");
        }
    }
}
