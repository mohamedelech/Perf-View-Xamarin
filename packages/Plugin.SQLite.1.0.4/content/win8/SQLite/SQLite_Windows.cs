using System.IO;
using Windows.Storage;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using XamarinForms.SQLite.Windows.SQLite;

[assembly: Dependency(typeof(SQLite_Windows))]

namespace XamarinForms.SQLite.Windows.SQLite
{
    public class SQLite_Windows : ISQLite
    {

        public SQLite_Windows()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "MySQLiteDB.db3";
            string documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}