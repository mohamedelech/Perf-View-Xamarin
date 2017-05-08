using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using Perf_View_Xamarin;

namespace XamarinSqliteSample
{
    public class PerformanceDB
    {
        private SQLiteConnection _sqlconnection;

        public PerformanceDB()
        {
            //Getting conection and Creating table  
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Performance>();
        }

        //Get all performances
        public List<Performance> GetPerformances()
        {
            return (from t in _sqlconnection.Table<Performance>() select t).ToList();
        }

        //Get specific performance 
        public Performance GetPerformance(int id)
        {
            return _sqlconnection.Table<Performance>().FirstOrDefault(t => t.ID == id);
        }

        //Delete specific performance
        public void DeletePerformance(int id)
        {
            _sqlconnection.Delete<Performance>(id);
        }

        //Add new performance to DB  
        public void AddPerformance(Performance perf)
        {
            _sqlconnection.Insert(perf);
        }
    }
}