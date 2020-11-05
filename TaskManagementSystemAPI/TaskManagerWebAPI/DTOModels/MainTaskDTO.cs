using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;

namespace TaskManagerWebAPI.DTOModels
{
    public class MainTaskDTO
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }
        public Guid userId { get; set; }
    }
}