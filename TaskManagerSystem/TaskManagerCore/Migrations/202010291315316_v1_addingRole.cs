namespace TaskManagerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1_addingRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginCredentials", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginCredentials", "Role");
        }
    }
}
