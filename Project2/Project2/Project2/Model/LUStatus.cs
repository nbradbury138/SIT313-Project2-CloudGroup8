using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace Project2.Model
{

    [Table("LUStatus")]
    public class LUStatus
    {
        [PrimaryKey]
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
