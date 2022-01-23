using Mobile_Project_Abdulkadir_Aksu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Mobile_Project_Abdulkadir_Aksu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        private readonly Geocoder _geocoder = new Geocoder();
        public TestPage()
        {
            InitializeComponent();
            CustomPin p = new CustomPin()
            {
                Type = PinType.Generic,
                Label = "pig spotted",
                Address = "rome",
                Position = new Position(41.9028, 12.4964),
                Name = "Pig spotted fam",
                Url = "https://www.nparks.gov.sg/gardens-parks-and-nature/dos-and-donts/animal-advisories/wild-boars"

            };
            customMap.CustomPins = new List<CustomPin> { p };
            customMap.Pins.Add(p);
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {

            CustomPin p = new CustomPin()
            {
                Type = PinType.Generic,
                Label = "pig spotted",
                Address = "geocoder doesnt work sometimes",
                Position = new Position(e.Position.Latitude, e.Position.Longitude),
                Name = "Pig spotted fam",
                Url = "https://www.nparks.gov.sg/gardens-parks-and-nature/dos-and-donts/animal-advisories/wild-boars"

            };
            customMap.CustomPins.Add(p);
            customMap.Pins.Add(p);
        }
    }
}