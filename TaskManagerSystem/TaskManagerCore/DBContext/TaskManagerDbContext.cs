
using System.Data.Entity;
using TaskManagerCore.Models;

namespace TaskManagerCore.DBContext
{
    class TaskManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoginCredentials> Credentials { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<UserSubTask> SubTasks { get; set; }

        public TaskManagerDbContext() : base("TaskManagerDb")
        {

        }
    }
}
