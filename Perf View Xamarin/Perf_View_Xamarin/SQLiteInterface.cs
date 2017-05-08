using SQLite.Net;
namespace XamarinSqliteSample
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}