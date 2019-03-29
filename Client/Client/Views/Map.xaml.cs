using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();

            MyMap.UiSettings.CompassEnabled = true;
            MyMap.UiSettings.MyLocationButtonEnabled = true;
            MyMap.UiSettings.RotateGesturesEnabled = true;
            MyMap.UiSettings.ScrollGesturesEnabled = true;
            MyMap.UiSettings.TiltGesturesEnabled = true;
        }
    }
}