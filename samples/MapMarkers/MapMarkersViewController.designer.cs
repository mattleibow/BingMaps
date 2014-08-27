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

namespace MapMarkers
{
	[Register ("MapMarkersViewController")]
	partial class MapMarkersViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		BingMaps.BMMapView mapView { get; set; }

		[Action ("BothClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BothClicked (UIBarButtonItem sender);

		[Action ("CityClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CityClicked (UIBarButtonItem sender);

		[Action ("NeedleClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void NeedleClicked (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}
		}
	}
}
