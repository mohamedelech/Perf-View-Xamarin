using Plugin.Compass;
using System;
using System.Diagnostics;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perf_View_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compass : ContentPage
    {
        public Compass()
        {
            InitializeComponent();
            CrossCompass.Current.CompassChanged += async (s, e) =>
            {
                Debug.WriteLine("*** Compass Heading = {0}", e.Heading);

                heading.Text = $"{Math.Round(e.Heading, 0)}" + "º";

                await img_Compass.RotateTo(Math.Round(e.Heading, 0), 2000);

            };

            CrossCompass.Current.Start();
        }
    }
}
