using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using BingMaps;

namespace BMTemplate
{
	partial class BMTemplateViewController : UIViewController
	{
		public BMTemplateViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// some basic logging
			mapView.Loading += (sender, e) => {
				Console.WriteLine ("Will start loading map...");
			};
			mapView.Loaded += (sender, e) => {
				Console.WriteLine ("Finished loading map.");
			};
			mapView.LoadingFailed += (sender, e) => {
				Console.WriteLine ("Error: " + e.Error.Description);
			};

			// setup
			mapView.ShowsUserLocation = true;
		}
	}
}
