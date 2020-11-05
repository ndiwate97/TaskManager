using System.Data.Entity;
using System.Threading.Tasks;
using TaskManagerCore.Models;

namespace TaskManagerCore.DBContext
{
    public class TaskManagerDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MainTask> MainTasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<LoginCredential> LoginCredentials { get; set; }
    }
}
