using System.IO;
using System;
using SQLite;
using Project2.Droid.Database;
using Project2.Helpers;
using Project2.Interfaces;
using Project2.Data;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]
namespace Project2.Droid.Database
{
    public class AndroidSQLite : SQLInterface
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
