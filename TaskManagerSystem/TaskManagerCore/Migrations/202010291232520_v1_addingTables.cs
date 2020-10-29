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
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        Pin = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Password = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        ProfilePicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TaskName = c.String(),
                        Description = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserSubTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        subTaskName = c.String(),
                        description = c.String(),
                        startDateTime = c.DateTime(nullable: false),
                        status = c.String(),
                        Task_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginCredentials", "Id", "dbo.Users");
            DropForeignKey("dbo.UserTasks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserSubTasks", "Task_Id", "dbo.UserTasks");
            DropIndex("dbo.LoginCredentials", new[] { "Id" });
            DropIndex("dbo.UserTasks", new[] { "User_Id" });
            DropIndex("dbo.UserSubTasks", new[] { "Task_Id" });
            DropTable("dbo.UserSubTasks");
            DropTable("dbo.UserTasks");
            DropTable("dbo.Users");
            DropTable("dbo.LoginCredentials");
        }
    }
}
