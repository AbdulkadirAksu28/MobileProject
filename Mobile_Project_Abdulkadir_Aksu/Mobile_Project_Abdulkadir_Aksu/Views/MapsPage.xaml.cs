using Mobile_Project_Abdulkadir_Aksu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Mobile_Project_Abdulkadir_Aksu.Models;
using Mobile_Project_Abdulkadir_Aksu.Services;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Mobile_Project_Abdulkadir_Aksu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public ObservableCollection<Item> Animals;
        public Command LoadAnimals { get; }
        private readonly Geocoder _geocoder = new Geocoder();
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        string _url;
        public MapsPage()
        {
            InitializeComponent();
            DisplayCurLocation();
            Animals = new ObservableCollection<Item>();
           
            CustomPin p = new CustomPin()
            {
                Type = PinType.Generic,
                Label = "pig spotted",
                Address = "Mijnterril Heusden-Zolder",
                Position = new Position(51.0593, 5.3285),
                Name = "Wild boars",
                Url = "https://www.nparks.gov.sg/gardens-parks-and-nature/dos-and-donts/animal-advisories/wild-boars"

            };
            MyMap.CustomPins = new List<CustomPin> { p };
            MyMap.Pins.Add(p);
            
            this.BindingContext = new MapsViewModel();
            //ApplyMapTheme();
        }
        public async void ExecuteLoadAnimals()
        {
            try
            {
                Animals.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Animals.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //private void ApplyMapTheme()
        //{
        //    var assembly = typeof(MapsPage).GetTypeInfo().Assembly;
        //    var stream = assembly.GetManifestResourceStream($"Mobile_Project_Abdulkadir_Aksu.MapResources.MapTheme.json");
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
            //await DisplayAlert("Coordinates", $"Lat: {e.Position.Latitude}, Long: {e.Position.Longitude}", "OK");
            //try
            //{
            //    var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);

            //    await DisplayAlert("Address", addresses.FirstOrDefault()?.ToString(), "OK");
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Error", "Unable to get address: " + ex, "OK");
            //}

            var adrs = await _geocoder.GetAddressesForPositionAsync(e.Position);
            DateTime today = DateTime.Now;
            string currentTime = today.ToString("h:mm tt");
            ExecuteLoadAnimals();
            string action = await DisplayActionSheet("Which animal have you spot", "Cancel", null, Animals.Select(animal => animal.Text).ToArray());
            Debug.WriteLine("Action: " + action);

            List<Item> i = Animals.Where(a => a.Text == action).ToList();


            if (action != "Cancel")
            {
                CustomPin p = new CustomPin()
                {
                    Type = PinType.Generic,
                    Label = $"{action} spotted at {currentTime}",
                    Address = adrs.FirstOrDefault()?.ToString(),
                    Position = new Position(e.Position.Latitude, e.Position.Longitude),
                    Name = action,
                    Url = i[0].URL,
                };
                MyMap.CustomPins.Add(p);
                MyMap.Pins.Add(p);
            }


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