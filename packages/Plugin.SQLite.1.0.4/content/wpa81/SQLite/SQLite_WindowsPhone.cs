using System.IO;
using Windows.Storage;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using XamarinForms.SQLite.WindowsPhone.SQLite;

[assembly: Dependency(typeof(SQLite_WindowsPhone))]

namespace XamarinForms.SQLite.WindowsPhone.SQLite
{
    public class SQLite_WindowsPhone : ISQLite
    {

        public SQLite_WindowsPhone()
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