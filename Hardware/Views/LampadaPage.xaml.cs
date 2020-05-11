using Android.Widget;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hardware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LampadaPage : ContentPage
    {
        public LampadaPage()
        {
            InitializeComponent();
        }

        private async void btnLampada_Clicked(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    // Turn On
                    await Flashlight.TurnOnAsync();

                    // Turn Off
                    await Flashlight.TurnOffAsync();
                    await Task.Delay(500);
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