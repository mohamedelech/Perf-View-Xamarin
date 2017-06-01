
using SQLite;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Plugin.Media;

namespace Perf_View_Xamarin
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBench : ContentPage
    {
        Geocoder geoCoder;
        private readonly SQLiteConnection _sqLiteConnection;

        public AddBench()
        {
            InitializeComponent();
            GetAddress();

            _sqLiteConnection = DependencyService.Get<XamarinForms.SQLite.SQLite.ISQLite>().GetConnection();
            _sqLiteConnection.CreateTable<Performance>();
        }

         private async void GetAddress()
        {
            Geocoder geoCoder = new Geocoder();
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var posLocator = await locator.GetPositionAsync(10000);

            var position = new Position(posLocator.Latitude, posLocator.Longitude);

            address.Text = posLocator.Latitude.ToString();

            //var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
           //foreach (var adr in possibleAddresses)
            // address.Text += adr + "\n";

        } 

        private async void SaveBenchPerf(object sender, EventArgs e)
        {

            _sqLiteConnection.Insert(new Performance
            {

                Date = date.Date.ToString("dd-MM-yyyy"),
                Movement = "Bench Press",
                Reps = reps.Text,
                Weight = weight.Text,
                Adresse = address.Text,
                Photo = pathLabel.Text

            });

            await Navigation.PushAsync(new ListView_Bench());
        }
        private async void ImportPhoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Oops", "Pick photo is not supported !", "OK");
                return;
            }

            btnImport.BackgroundColor = Color.Green;

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            pathLabel.Text = file.Path;

            ImportedImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}
