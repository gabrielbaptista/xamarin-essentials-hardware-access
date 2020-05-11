using Android.Content;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hardware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoPage : ContentPage
    {
        public GeoPage()
        {
            InitializeComponent();
        }

        private async void btnGeo_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Toast toast = Toast.MakeText(Android.App.Application.Context,
                        $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}", ToastLength.Long);
                    toast.Show();
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                Toast toast = Toast.MakeText(Android.App.Application.Context, ex.ToString(), ToastLength.Short);
                toast.Show();
            }
            catch (PermissionException ex)
            {
                Toast toast = Toast.MakeText(Android.App.Application.Context, ex.ToString(), ToastLength.Short);
                toast.Show();
            }
            catch (Exception ex)
            {
                Toast toast = Toast.MakeText(Android.App.Application.Context, ex.ToString(), ToastLength.Short);
                toast.Show();
            }
        }
    }
}