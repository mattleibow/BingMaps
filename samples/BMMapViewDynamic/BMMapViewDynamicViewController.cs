using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using BingMaps;

namespace BMMapViewDynamic
{
	partial class BMMapViewDynamicViewController : UIViewController
	{
		private BMMapView mapView;

		public BMMapViewDynamicViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// create the map view
			mapView = new BMMapView (UIScreen.MainScreen.Bounds);
			View.AddSubview (mapView);

			// map settings
			mapView.LoadingFailed += (sender, e) => {
				Console.WriteLine ("Error: " + e.Error.Description);
			};

			mapView.ShowsUserLocation = true;
		}
	}
}
