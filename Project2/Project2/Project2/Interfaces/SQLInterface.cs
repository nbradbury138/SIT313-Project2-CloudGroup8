using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;

namespace Project2.Interfaces
{
    //interface created to ensure both ios and android use the sqlite getconnection method.
    interface SQLInterface
    {
        SQLiteConnection GetConnection();
    }
}
