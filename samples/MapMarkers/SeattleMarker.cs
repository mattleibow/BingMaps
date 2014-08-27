using System;

using MonoTouch.CoreLocation;

using BingMaps;

namespace MapMarkers
{
	public class SeattleMarker : BMMarker
	{
		public override CLLocationCoordinate2D GetCoordinate ()
		{
			return new CLLocationCoordinate2D (47.59962, -122.33413);
		}

		public override string GetTitle ()
		{
			return "Seattle";
		}

		public override string GetSubtitle ()
		{
			return "Founded: Nov. 13, 1851";
		}
	}
}

