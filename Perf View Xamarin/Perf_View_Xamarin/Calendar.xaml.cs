using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace Perf_View_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendar : ContentPage
    {
        private readonly SQLiteConnection _sqLiteConnection;
        CalendarVM _vm;
        List<SpecialDate> dates;
        TableQuery<Agenda> allagendas;
        public Calendar()
        {
            InitializeComponent();
            _sqLiteConnection = DependencyService.Get<XamarinForms.SQLite.SQLite.ISQLite>().GetConnection();
            _sqLiteConnection.CreateTable<Agenda>();

            _vm = new CalendarVM();
            BindingContext = _vm;

            dates = new List<SpecialDate>();

            allagendas = _sqLiteConnection.Table<Agenda>();
            foreach (var ag in allagendas)
            {         
                var specialDate = new SpecialDate(new DateTime(ag.Date.Year, ag.Date.Month, ag.Date.Day));
                specialDate.BackgroundColor = Color.Green;
                dates.Add(specialDate);
            }

            _vm.Attendances = new ObservableCollection<SpecialDate>(dates);

        }


        public static readonly BindableProperty SelectedDatesProperty = BindableProperty.Create(nameof(SelectedDates), typeof(List<DateTime>), typeof(Calendar), new List<DateTime>(1));
        /// <summary>
        /// Gets the selected dates when MultiSelectDates is true
        /// </summary>
        /// <value>The selected date.</value>
        public List<DateTime> SelectedDates
        {
            get { return (List<DateTime>)GetValue(SelectedDatesProperty); }
            protected set { SetValue(SelectedDatesProperty, value); }
        }

        private async Task Calendar_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            DateTime dateTime = e.DateTime.Date;
            var specialDate = new SpecialDate(new DateTime(dateTime.Date.Year, dateTime.Date.Month, dateTime.Date.Day));

            if (dates.Contains(specialDate) && _sqLiteConnection.Get<Agenda>().Date == dateTime)
            {
                Agenda agenda = _sqLiteConnection.Get<Agenda>(specialDate);
                //_sqLiteConnection.Delete<Agenda>(agenda);
                _sqLiteConnection.DeleteAll<Agenda>();

             // dates.Remove(specialDate);
                dates.Clear();

                _vm.Attendances = new ObservableCollection<SpecialDate>(dates);
            }
            else
            {
                _sqLiteConnection.Insert(new Agenda
                {
                    Date = dateTime
                });
            }

            await Navigation.PushAsync(new listAgenda());
        }
    }
}
