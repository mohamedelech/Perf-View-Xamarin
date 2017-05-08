using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perf_View_Xamarin
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView_Bench : ContentPage
    {
        public ListView_Bench()
        {
            InitializeComponent();
            BindingContext = new ViewModel();
        }
        private async void GoToAddBench(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBench());
        }     

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Performance perf = e.SelectedItem as Performance;
            await Navigation.PushAsync(new DetailBench(perf));
        }
    }

    class ListView_BenchViewModel : INotifyPropertyChanged
    {

        public ListView_BenchViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
