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

namespace BMTemplate
{
	[Register ("BMTemplateViewController")]
	partial class BMTemplateViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		BingMaps.BMMapView mapView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}
		}
	}
}
