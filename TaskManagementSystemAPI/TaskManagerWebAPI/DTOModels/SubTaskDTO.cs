using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.DTOModels
{
    public class SubTaskDTO
    {
        public Guid Id { get; set; }
        public string SubTaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }
    }
}