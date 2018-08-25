using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

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
    }
}
