using System;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

using BingMaps;

using CGPoint = global::System.Drawing.PointF;

namespace LocationMap
{
	partial class LocationMapViewController : UIViewController
	{
		private BMReverseGeocoder reverseGeocode;

		public LocationMapViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			mapView.ShowsUserLocation = true;

			mapView.Loading += (sender, e) => {
				Console.WriteLine ("Will start loading map...");
			};
			mapView.Loaded += (sender, e) => {
				Console.WriteLine ("Finished loading map.");
			};
			mapView.LoadingFailed += (sender, e) => {
				Console.WriteLine ("Error: " + e.Error.Description);
			};
			mapView.RegionChanging += (sender, e) => {
				BMCoordinateRegion region = mapView.Region;
				Console.WriteLine("Region changing: animated={0}; center={1},{2}, span={3},{4}",
					e.Animated, 
					region.Center.Latitude, region.Center.Longitude, 
					region.Span.LatitudeDelta, region.Span.LongitudeDelta);
			};
			mapView.RegionChanged += (sender, e) => {
				BMCoordinateRegion region = mapView.Region;
				Console.WriteLine("Region changed: animated={0}; center={1},{2}, span={3},{4}",
					e.Animated, 
					region.Center.Latitude, region.Center.Longitude, 
					region.Span.LatitudeDelta, region.Span.LongitudeDelta);
			};
		}

		public override void ViewDidAppear (bool animated)
		{
			// set region to Cape Town, South Africa

			CLLocationCoordinate2D coords;
			coords.Latitude = -33.925278;
			coords.Longitude = 18.423889;

			BMCoordinateSpan span;
			span.LatitudeDelta = 5;
			span.LongitudeDelta = 5;

			BMCoordinateRegion region = BMMapView.BMCoordinateRegionMake( coords, span );
			region = mapView.RegionThatFits(region);
			mapView.SetRegion(region, true);
		}

		partial void ZoomClicked (UIBarButtonItem sender)
		{
			// Zoom to User Location

			CLLocation loc = mapView.UserLocation.Location;

			BMCoordinateSpan span;
			span.LatitudeDelta = loc.HorizontalAccuracy / 20000;
			span.LongitudeDelta = loc.VerticalAccuracy / 20000;

			BMCoordinateRegion region = BMMapView.BMCoordinateRegionMake( loc.Coordinate, span );
			region = mapView.RegionThatFits(region);
			mapView.SetRegion(region, true);
		}

		partial void FitClicked (UIBarButtonItem sender)
		{
			// Fit to world view
			BMCoordinateRegion region = new BMCoordinateRegion ();
			region.Center.Latitude = 0;
			region.Center.Longitude = 0;
			region.Span.LatitudeDelta = 400;
			region.Span.LongitudeDelta = 400;
			region = mapView.RegionThatFits (region);
			mapView.SetRegion (region, true);
		}

		partial void MapModeClicked (UIBarButtonItem sender)
		{
			BMMapMode current = mapView.MapMode;
			BMMapMode next;
			switch (current) {
			case BMMapMode.Road:
				next = BMMapMode.AerialWithLabels;
				break;
			case BMMapMode.AerialWithLabels:
				next = BMMapMode.Aerial;
				break;
			default:
			case BMMapMode.Aerial:
				next = BMMapMode.Road;
				break;
			}
			mapView.MapMode = next;
		}

		partial void ReverseGeoCodeClicked (UIBarButtonItem sender)
		{
			//Initialize the reverse geocoder instance with the current region's center point
			reverseGeocode = new BMReverseGeocoder (mapView.Region.Center);
			reverseGeocode.Failed += (_, e) => {
				Console.WriteLine ("Failed reverse geocoding with error: {0}", e.Error.Description);

				InvokeOnMainThread (() => {
					using (UIAlertView reverseGeocodeAlert = new UIAlertView ("Error", e.Error.LocalizedDescription, null, "Ok", null))
						reverseGeocodeAlert.Show ();
				});
			};
			reverseGeocode.EntityFound += (_, e) => {
				Console.WriteLine ("Reverse geocoder has returned: {0}", e.Entity.AddressDictionary);
				
				//Show the results of the reverse geocode operation as an alert
				InvokeOnMainThread (() => {
					using (UIAlertView reverseGeocodeAlert = new UIAlertView (e.Entity.AdminDistrict, e.Entity.FormattedAddress, null, "Ok", null))
						reverseGeocodeAlert.Show ();
				});
			};
			reverseGeocode.Start ();
		}
	}
}
