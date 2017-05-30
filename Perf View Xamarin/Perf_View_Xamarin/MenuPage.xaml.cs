using Plugin.Media;
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
    public partial class MenuPage : MasterDetailPage
    {

        public MenuPage()
        {
            InitializeComponent();
           // NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void GoToBenchListAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListView_Bench());
        }

        private async void TakePhoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            System.Diagnostics.Debug.WriteLine("OK : await CrossMedia.Current.Initialize()");
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                        await DisplayAlert("No Camera", " No camera available.", "OK");
                return;
            }

            System.Diagnostics.Debug.WriteLine("OK 2");

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                    SaveToAlbum = true
            });

                if (file == null)
                    return;

            System.Diagnostics.Debug.WriteLine("OK 3");

            //await DisplayAlert("File Location", file.Path, "OK");
        }

        private async void TakeVideo(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                await DisplayAlert("No Camera", " No video available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                SaveToAlbum = true
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");
        }
    }
}
