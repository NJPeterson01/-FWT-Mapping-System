using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using MapOverlay;

namespace FFS
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

		}
        //Get Geolocation Lat and Long
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync();

            LoadMap(position.Longitude, position.Latitude);
        }
        //Generate Map
        private void LoadMap(double log, double lat)
        {
            ////Get JSON
            //string[] routeLocations = GetJson();

            //Generate Cutsom Map
            var customMap = new CustomMap
            {
                MapType = MapType.Street,
                IsShowingUser = true,
                WidthRequest = App.ScreenWidth,
                HeightRequest = App.ScreenHeight
            };

            //Center Camera to Location -> From Geolocation
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, log), Distance.FromMiles(1.0)));
            Content = customMap;

            ////Process Routes
            //foreach(string route in routeLocations)
            //{
            //    //Read JSON String From File
            //    var getJson = System.IO.File.ReadAllText(route);
            //    //Convert JSON From File
            //    var data = JsonConvert.DeserializeObject<Geometry>(getJson);

            //    //Pull Out all Coordinates in Json
            //    //Add Each Coordinate to Map
            //    foreach(var coordinate in data.coordinates)
            //    {
            //        customMap.RouteCoordinates.Add(new Position(coordinate[0], coordinate[1]));
            //    }
            //}

            //Set Route Coordinate 
            //customMap.RouteCoordinates.Add(new Position(41.797534, -85.401827));
            //customMap.RouteCoordinates.Add(new Position(41.797534, -85.901827));



            /*
            //Generate Pin
            var pin = new Pin()
            {
                Position = new Position(lat, log),
                Label = "Current Location"
            };
            */
            //Add Pin to Map
            //customMap.Pins.Add(pin);
        }
        //Fetch Json Files
        //private string[] GetJson()
        //{
        //    //Get Files in Specified File Location
        //    string path = @"C:\Users";
        //    string[] LocationJson = Directory.GetFiles(path.Trim());

        //    foreach (string directory in LocationJson)
        //    {
        //        Console.WriteLine(directory);
        //    }

        //    return LocationJson;
        //}
    }
}
