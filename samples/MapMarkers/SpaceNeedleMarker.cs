using System;

using MonoTouch.CoreLocation;

using BingMaps;

namespace MapMarkers
{
	public class SpaceNeedleMarker : BMMarker
	{
		public override CLLocationCoordinate2D GetCoordinate ()
		{
			return new CLLocationCoordinate2D (47.61989, -122.34825);
		}

		public override string GetTitle ()
		{
			return "Space Needle";
		}

		public override string GetSubtitle ()
		{
			return "Opened: April 21, 1962";
		}
	}
}

