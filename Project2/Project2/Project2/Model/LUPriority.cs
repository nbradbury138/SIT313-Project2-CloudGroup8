using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Project2.Model
{
    [Table("LUPriority")]
    public class LUPriority
    {
        [PrimaryKey]
        public string PriorityCode { get; set; }
        public string PriorityDescription { get; set; }

        public LUPriority()
        {

        }

        public LUPriority(string priorityCode, string priorityDescription)
        {
            PriorityCode = priorityCode;
            PriorityDescription = priorityDescription;
        }

    }
}
