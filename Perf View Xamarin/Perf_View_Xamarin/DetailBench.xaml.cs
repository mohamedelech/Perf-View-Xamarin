using Plugin.Media;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perf_View_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailBench : ContentPage
    {
        private readonly SQLiteConnection _sqLiteConnection;
        private Performance perfDetail;
        public DetailBench(Performance perf)
        {
            InitializeComponent();
            _sqLiteConnection = DependencyService.Get<XamarinForms.SQLite.SQLite.ISQLite>().GetConnection();

            date.Text = perf.Date;
            weight.Text = perf.Weight;
            reps.Text = perf.Reps;
            address.Text = perf.Adresse;

            ImportedImage.Source = ImageSource.FromFile(perf.Photo);
            pathLabel.Text = perf.Photo;

            perfDetail = perf;

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

        private async void Update()
        {
           perfDetail.Date = date.Text;
           perfDetail.Weight = weight.Text;
           perfDetail.Reps = reps.Text;
           perfDetail.Adresse = address.Text;
           perfDetail.Photo = pathLabel.Text;

            _sqLiteConnection.Update(perfDetail);
            await Navigation.PushAsync(new ListView_Bench());
        }

        private async void Delete()
        {
            _sqLiteConnection.Delete(perfDetail);
            await Navigation.PushAsync(new ListView_Bench());
        }


    }
}
