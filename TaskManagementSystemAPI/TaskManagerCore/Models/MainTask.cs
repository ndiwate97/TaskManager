using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class MainTask
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public ICollection<SubTask> SubTask { get; set; }

        public MainTask()
        {
            Id = Guid.NewGuid();
        }
    }
}
