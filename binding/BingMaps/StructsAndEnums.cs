using System;

using MonoTouch.CoreLocation;

using CLLocationDegrees = global::System.Double;

namespace BingMaps
{

	public enum BMMapMode : uint {
		Road = 0,
		Aerial,
		AerialWithLabels
	}

	public enum BMErrorCode : uint {
		Unknown = 1,
		ServerFailure,
		LoadingThrottled,
		EntityNotFound,
		AuthenticationFailure
	}

	public enum BMPushpinColor : uint {
		Orange = 0,
		Green,
		Red,
		Blue,
		Yellow,
		Purple
	}

	public struct BMCoordinateSpan
	{
		public CLLocationDegrees LatitudeDelta;
		public CLLocationDegrees LongitudeDelta;
	}

	public struct BMCoordinateRegion
	{
		public CLLocationCoordinate2D Center;
		public BMCoordinateSpan Span;
	}

}

