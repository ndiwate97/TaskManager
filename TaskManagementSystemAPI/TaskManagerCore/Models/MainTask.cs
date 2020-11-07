using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class MainTask
    {
        [Key]
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<SubTask> SubTask { get; set; }

        public MainTask()
        {
            TaskId = Guid.NewGuid();
        }
    }
}
