namespace TaskManagerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3_updatingChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSubTasks", "SubTaskName", c => c.String());
            AlterColumn("dbo.UserSubTasks", "Description", c => c.String());
            AlterColumn("dbo.UserSubTasks", "StartDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserSubTasks", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSubTasks", "Status", c => c.String());
            AlterColumn("dbo.UserSubTasks", "StartDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserSubTasks", "Description", c => c.String());
            AlterColumn("dbo.UserSubTasks", "SubTaskName", c => c.String());
        }
    }
}
