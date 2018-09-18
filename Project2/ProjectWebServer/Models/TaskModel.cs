using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebServer.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime LastModifiedDate { get; set; }


        public TaskModel()
        {

        }

        public TaskModel(string name, string desc, string priority, string user, string status, DateTime duedate, DateTime lastModified)
        {
            TaskName = name;
            Description = desc;
            Priority = priority;
            User = user;
            Status = status;
            DueDate = duedate;
            LastModifiedDate = lastModified;
        }

        public override string ToString()
        {
            return TaskName;
        }
    }
}