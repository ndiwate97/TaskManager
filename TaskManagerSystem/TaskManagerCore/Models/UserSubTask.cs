using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class UserSubTask
    {
        public Guid Id { get; set; }
        public string SubTaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }
        public UserTask Task { get; set; }
    }
}