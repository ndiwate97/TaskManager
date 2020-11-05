using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerCore.Models
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public User User { get; set; }
        public List<UserSubTask> SubTasks { get; set; }

        public UserTask()
        {
            SubTasks = new List<UserSubTask>();
            Id = Guid.NewGuid();
        }
    }
}