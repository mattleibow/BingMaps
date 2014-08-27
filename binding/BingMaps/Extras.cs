using System;
using System.Runtime.InteropServices;

using MonoTouch.CoreLocation;
using MonoTouch.ObjCRuntime;

namespace BingMaps
{
//		public static class BMMarker_Manual_Extensions
//		{
//			public static CLLocationCoordinate2D GetCoordinate (this IBMMarker This)
//			{
//				CLLocationCoordinate2D result;
//				Messaging.CLLocationCoordinate2D_objc_msgSend_stret (out result, This.Handle, Selector.GetHandle ("coordinate"));
//				return result;
//			}
//		}
//	
//	    partial class Messaging
//		{
//			[DllImport ("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
//			public static extern void CLLocationCoordinate2D_objc_msgSend_stret (out CLLocationCoordinate2D retval, IntPtr receiver, IntPtr selector);
//		}
//
//
//		public partial class BMUserLocation
//		{
//			public virtual string Title {
//				get {
//					return GetTitle ();
//				}
//				set {
//					SetTitle (value);
//				}
//			}
//	
//			public virtual string Subtitle {
//				get {
//					return GetSubtitle ();
//				}
//				set {
//					SetSubtitle (value);
//				}
//			}
//		}
//	
//		public partial class BMMarker
//		{
//			public virtual string Title {
//				get {
//					return GetTitle ();
//				}
//			}
//	
//			public virtual string Subtitle {
//				get {
//					return GetSubtitle ();
//				}
//			}
//		}
//

	public partial class BMMapView
	{

		public static BMCoordinateSpan BMCoordinateSpanMake (double latitudeDelta, double longitudeDelta)
		{
			BMCoordinateSpan span;
			span.LatitudeDelta = latitudeDelta;
			span.LongitudeDelta = longitudeDelta;
			return span;
		}

		public static BMCoordinateRegion BMCoordinateRegionMake (CLLocationCoordinate2D centerCoordinate, BMCoordinateSpan span)
		{
			BMCoordinateRegion region;
			region.Center = centerCoordinate;
			region.Span = span;
			return region;
		}

	}
}

