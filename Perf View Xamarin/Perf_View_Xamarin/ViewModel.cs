using SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;


namespace Perf_View_Xamarin
{
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _sqLiteConnection;
        private List<Performance> _performancesList;

        public List<Performance> PerformancesList
        {
            get { return _performancesList; }
            set
            {
                _performancesList = value;
                OnpropertyChanged();
            }
        }

        public ViewModel()
        {
            _sqLiteConnection = DependencyService.Get<XamarinForms.SQLite.SQLite.ISQLite>().GetConnection();
            _sqLiteConnection.CreateTable<Performance>();

            var alltables = _sqLiteConnection.Table<Performance>();
            PerformancesList = new List<Performance>();
            foreach (var perf in alltables)
            {
                PerformancesList.Add(perf);
            }


             
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
