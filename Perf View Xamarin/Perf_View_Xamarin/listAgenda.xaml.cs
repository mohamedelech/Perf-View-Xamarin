using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perf_View_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listAgenda : ContentPage
    {
        private readonly SQLiteConnection _sqLiteConnection = DependencyService.Get<XamarinForms.SQLite.SQLite.ISQLite>().GetConnection();
        public listAgenda()
        {
            InitializeComponent();
            BindingContext = new ViewModelAgenda();
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Agenda ag = e.SelectedItem as Agenda;
            _sqLiteConnection.Delete(ag);
            await Navigation.PushAsync(new listAgenda());
        }

    }
}
