namespace TaskManagerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2_updatingChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTasks", "Priority", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.UserTasks", "Priority");
        }
    }
}
