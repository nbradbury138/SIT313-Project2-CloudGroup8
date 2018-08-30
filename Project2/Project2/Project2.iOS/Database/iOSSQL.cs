using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using Project2.Helpers;
using Project2.iOS.Database;
using Project2.Interfaces;

[assembly: Dependency(typeof(IOSSQLite))]
namespace Project2.iOS.Database
{
    public class IOSSQLite : SQLInterface
    {
        SQLiteConnection connection;

        public SQLiteConnection GetConnection()
        {
            //set folder location.
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //set path
            var path = Path.Combine(documentsPath, DBHelper.fileName);

            //if the file doesn't exist then create it. In both cases open the connection.
            if (!File.Exists(path))
            {
                File.Create(path);
                connection = new SQLiteConnection(path);
            }
            else
            {
                connection = new SQLiteConnection(path);
            }

            // Return the database connection  
            return connection;
        }
    }
}

