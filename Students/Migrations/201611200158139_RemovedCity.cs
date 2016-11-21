namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "City", c => c.String());
        }
    }
}
