
using AudioManager;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Plugin.MediaManager;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perf_View_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accelerometre : ContentPage
    {
        public Accelerometre()
        {
            InitializeComponent();
        }

        private void BtnStart_OnClicked(object sender, EventArgs e)
        {
            CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);
            CrossDeviceMotion.Current.SensorValueChanged += async (s, a) =>
            {
                switch (a.SensorType)
                {
                    case MotionSensorType.Accelerometer:
                        lblXAxis.Text = ((MotionVector)a.Value).X.ToString("F");
                        lblYAxis.Text = ((MotionVector)a.Value).Y.ToString("F");
                        lblZAxis.Text = ((MotionVector)a.Value).Z.ToString("F");
                        break;
                }
            };
        }

        private void BtnStop_OnClicked(object sender, EventArgs e)
        {
            CrossDeviceMotion.Current.Stop(MotionSensorType.Accelerometer);
        }
    }
}
