using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class SubTask
    {
        public Guid Id { get; set; }
        public string SubTaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }
        public MainTask Task { get; set; }
    }
}
