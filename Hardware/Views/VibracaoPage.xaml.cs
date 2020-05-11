using Android.Widget;
using System;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hardware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VibracaoPage : ContentPage
    {
        public VibracaoPage()
        {
            InitializeComponent();
        }

        private void btnVibracao_Clicked(object sender, EventArgs e)
        {
            try
            {

                // Or use specified time
                var duration = TimeSpan.FromMilliseconds(500);
                for (int i = 0; i < 3; i++)
                {
                    Vibration.Vibrate(duration);
                    Thread.Sleep(500);
                }
            }
            catch (FeatureNotSupportedException ex)
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