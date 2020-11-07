namespace TaskManagerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1_addingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginCredentials",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        City = c.String(),
                        ContactNumber = c.Long(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.MainTasks",
                c => new
                    {
                        TaskId = c.Guid(nullable: false),
                        TaskName = c.String(),
                        Description = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        SubTaskId = c.Guid(nullable: false),
                        SubTaskName = c.String(),
                        Description = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        TaskId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SubTaskId)
                .ForeignKey("dbo.MainTasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginCredentials", "Id", "dbo.Users");
            DropForeignKey("dbo.MainTasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.SubTasks", "TaskId", "dbo.MainTasks");
            DropIndex("dbo.SubTasks", new[] { "TaskId" });
            DropIndex("dbo.MainTasks", new[] { "UserId" });
            DropIndex("dbo.LoginCredentials", new[] { "Id" });
            DropTable("dbo.SubTasks");
            DropTable("dbo.MainTasks");
            DropTable("dbo.Users");
            DropTable("dbo.LoginCredentials");
        }
    }
}
