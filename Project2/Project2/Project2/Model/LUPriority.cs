using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace Project2.Model
{
    [Table("LUPriority")]
    public class LUPriority
    {
        [PrimaryKey]
        public string PriorityCode { get; set; }
        public string PriorityDescription { get; set; }
    }
}
