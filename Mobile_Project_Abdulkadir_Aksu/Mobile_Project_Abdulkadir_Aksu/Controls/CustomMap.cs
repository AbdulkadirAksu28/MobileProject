using Mobile_Project_Abdulkadir_Aksu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Mobile_Project_Abdulkadir_Aksu.Controls
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}
