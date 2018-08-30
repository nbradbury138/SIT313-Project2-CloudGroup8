using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Project2.Model
{
    [Table("UserData")]
    public class UserData
    {
        [PrimaryKey]
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserData()
        {

        }

        public UserData(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
