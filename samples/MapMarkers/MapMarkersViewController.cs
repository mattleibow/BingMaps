using System;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using BingMaps;

using CGPoint = global::System.Drawing.PointF;

namespace MapMarkers
{
	partial class MapMarkersViewController : UIViewController
	{
		private const string SpaceNeedleMarkerIdentifier = "spaceNeedleMarkerIdentifier";
		private const string SeattleMarkerIdentifier = "seattleMarkerIdentifier";

		private readonly BMMarker[] mapMarkers = {
			new SeattleMarker (),
			new SpaceNeedleMarker ()
		};

		public MapMarkersViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			mapView.ShowsUserLocation = false;

			mapView.Loading += (sender, e) => {
				Console.WriteLine ("Will start loading map...");
			};
			mapView.Loaded += (sender, e) => {
				Console.WriteLine ("Finished loading map.");
			};
			mapView.LoadingFailed += (sender, e) => {
				Console.WriteLine ("Error: " + e.Error.Description);
			};

			mapView.GetMarkerView = GetMarkerView;

			GoToLocation ();
		}

		public BMMarkerView GetMarkerView (BMMapView mapView, BMMarker marker)
		{
			if (marker is SpaceNeedleMarker) {
				BMMarkerView pinView = mapView.DequeueReusableMarkerView (SpaceNeedleMarkerIdentifier);
				if (pinView == null) {
					BMPushpinView markerView = new BMPushpinView (marker, SpaceNeedleMarkerIdentifier);
					markerView.PinColor = BMPushpinColor.Red;
					markerView.CanShowCallout = true;
					markerView.Enabled = true;
					markerView.Opaque = false;

					UIButton rightButton = new UIButton (UIButtonType.DetailDisclosure);
					rightButton.TouchUpInside += (sender, e) => {
						PerformSegue ("ShowDetailsSegue", this);
					};
					markerView.CalloutAccessoryView2 = rightButton;

					return markerView;
				} else {
					pinView.Marker = marker;
				}
				return pinView;
			} else if (marker is SeattleMarker) {
				BMMarkerView pinView = mapView.DequeueReusableMarkerView (SeattleMarkerIdentifier);
				if (pinView == null) {
					BMPushpinView markerView = new BMPushpinView (marker, SeattleMarkerIdentifier);
					markerView.CanShowCallout = true;
					markerView.Enabled = true;
					markerView.Opaque = false;

					using (UIImage icon = UIImage.FromBundle ("Home.png"))
					using (UIImageView seattleIconView = new UIImageView (icon))
					using (UIImage cityImage = UIImage.FromBundle ("pin_Misc.png")) {
						markerView.Image = cityImage;
						markerView.CenterOffset = new CGPoint (cityImage.Size.Width / 2F - 17.0F, -cityImage.Size.Height / 2F);
						markerView.CalloutAccessoryView1 = seattleIconView;
					}
					return markerView;
				} else {
					pinView.Marker = marker;
				}
				return pinView;
			}

			return null;
		}

		private void GoToLocation ()
		{
			BMCoordinateRegion newRegion = new BMCoordinateRegion ();
			newRegion.Center.Latitude = 47.60445;
			newRegion.Center.Longitude = -122.34156;
			newRegion.Span.LatitudeDelta = 0.071872;
			newRegion.Span.LongitudeDelta = 0.080863;

			mapView.SetRegion (newRegion, true);
		}

		partial void CityClicked (UIBarButtonItem sender)
		{
			GoToLocation ();
			mapView.RemoveMarkers (mapView.Markers);
			mapView.AddMarker (mapMarkers [0]);
		}

		partial void NeedleClicked (UIBarButtonItem sender)
		{
			GoToLocation ();
			mapView.RemoveMarkers (mapView.Markers);
			mapView.AddMarker (mapMarkers [1]);
		}

		partial void BothClicked (UIBarButtonItem sender)
		{
			GoToLocation ();
			mapView.RemoveMarkers (mapView.Markers);
			mapView.AddMarkers (mapMarkers);
		}
	}
}
