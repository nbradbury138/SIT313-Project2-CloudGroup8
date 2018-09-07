using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Project2.Model
{

    [Table("LUStatus")]
    public class LUStatus
    {
        [PrimaryKey]
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public LUStatus()
        {

        }

        public LUStatus(string statusCode, string statusDesc)
        {
            StatusCode = statusCode;
            StatusDescription = statusDesc;
        }
    }
}
