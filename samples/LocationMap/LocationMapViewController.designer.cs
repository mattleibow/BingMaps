// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace LocationMap
{
	[Register ("LocationMapViewController")]
	partial class LocationMapViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		BingMaps.BMMapView mapView { get; set; }

		[Action ("FitClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void FitClicked (UIBarButtonItem sender);

		[Action ("MapModeClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void MapModeClicked (UIBarButtonItem sender);

		[Action ("ReverseGeoCodeClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ReverseGeoCodeClicked (UIBarButtonItem sender);

		[Action ("ZoomClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ZoomClicked (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}
		}
	}
}
