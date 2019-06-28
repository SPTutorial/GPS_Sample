using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPS_Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetPosition(object sender, EventArgs e)
        {
            if(CrossGeolocator.Current.IsGeolocationAvailable)
            {
                if(CrossGeolocator.Current.IsGeolocationEnabled)
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;

                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                    Device.BeginInvokeOnMainThread(() => {
                        latitude.Text = $"Latitude : {position.Latitude}";
                        longitude.Text = $"Longitude : {position.Longitude}";
                        accuracy.Text = $"Accuracy : {Convert.ToInt32( position.Accuracy)} Meter";
                    });
                }
                else
                {
                    await DisplayAlert("Message", "GPS Not Enabled", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Message", "GPS Not Available", "Ok");
            }
        }
    }
}
