using Project_Mobile_Abdulkadir_Aksu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Project_Mobile_Abdulkadir_Aksu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        private readonly Geocoder _geocoder = new Geocoder();
        public MapsPage()
        {
            InitializeComponent();
            DisplayCurLocation();
            this.BindingContext = new MapsViewModel();
            //ApplyMapTheme();
        }

        //private void ApplyMapTheme()
        //{
        //    var assembly = typeof(MapsPage).GetTypeInfo().Assembly;
        //    var stream = assembly.GetManifestResourceStream($"Project_Mobile_Abdulkadir_Aksu.MapResources.MapTheme.json");
        //    string themeFile;
        //    using (var reader = new System.IO.StreamReader(stream))
        //    {
        //        themeFile = reader.ReadToEnd();
        //    }
            
        //}

        public async void DisplayCurLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(0.444));
                    MyMap.MoveToRegion(mapSpan);
                    MyMap.IsShowingUser = true;
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        async void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            await DisplayAlert("Coordinates", $"Lat: {e.Position.Latitude}, Long: {e.Position.Longitude}", "OK");

            var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);

            await DisplayAlert("Address", addresses.FirstOrDefault()?.ToString(), "OK");

            //var positions = await _geocoder.GetPositionsForAddressAsync("PXL, Hasselt");

            //await DisplayAlert("Position", $"Lat: {positions.First().Latitude}, Long: {positions.First().Longitude}", "OK");

            //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(positions.First(), Distance.FromKilometers(0.333)));
        }
        //private async void LogoutClicked(object sender, EventArgs e)
        //{
        //    App.IsUserLoggedIn = false;
        //    Preferences.Set("isLoggedIn", false);
        //    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            
        //}
    }
}