namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init01 : DbMigration
    {
        public override void Up()
        {
            // EF will update the column if it does not exist
           // AddColumn("dbo.task", "createdate", x => x.DateTime());
        }
        
        public override void Down()
        {
            DropTable("dbo.user");
            DropTable("dbo.task");
        }
    }
}
