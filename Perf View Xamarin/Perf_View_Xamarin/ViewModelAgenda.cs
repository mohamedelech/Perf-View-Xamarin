using SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;


namespace Perf_View_Xamarin
{
    public class ViewModelAgenda : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _sqLiteConnection;
        private List<Agenda> _agendasList;

        public List<Agenda> AgendasList
        {
            get { return _agendasList; }
            set
            {
                _agendasList = value;
                OnpropertyChanged();
            }
        }

        public ViewModelAgenda()
        {
            _sqLiteConnection = DependencyService.Get<XamarinForms.SQLite.SQLite.ISQLite>().GetConnection();
            _sqLiteConnection.CreateTable<Agenda>();

            var alltables = _sqLiteConnection.Table<Agenda>();
            AgendasList = new List<Agenda>();
            foreach (var ag in alltables)
            {
                AgendasList.Add(ag);
            }             
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
