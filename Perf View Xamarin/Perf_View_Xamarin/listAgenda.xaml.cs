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
        public listAgenda()
        {
            InitializeComponent();
            BindingContext = new ViewModelAgenda();
        }
    }
}
