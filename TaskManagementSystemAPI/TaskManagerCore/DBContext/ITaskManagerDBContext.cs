using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore.Models;

namespace TaskManagerCore.DBContext
{
    interface ITaskManagerDBContext
    {
        DbSet<User> Users { get; set; }
        DbSet<MainTask> MainTasks { get; set; }
        DbSet<SubTask> SubTasks { get; set; }
        DbSet<LoginCredential> LoginCredentials { get; set; }
    }
}
