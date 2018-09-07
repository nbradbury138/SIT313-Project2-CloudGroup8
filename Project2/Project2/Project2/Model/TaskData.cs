using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Project2.Model
{
    [Table("TaskData")]
    public class TaskData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }


        public TaskData()
        {

        }

        public TaskData(string name, string desc, string priority, string user, string status, DateTime duedate)
        {
            TaskName = name;
            Description = desc;
            Priority = priority;
            User = user;
            Status = status;
            DueDate = duedate;
        }

        public override string ToString()
        {
            return TaskName;
        }


    }
}
