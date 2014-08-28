using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;

namespace BingMaps
{
	//	[DllImport ("/Users/matthew/projects/BingMaps/BingMaps/BMTypes.h")]
	//	static extern string BMErrorDomain { get; }

	// // Post this notification to re-query callout information.
	// UIKIT_EXTERN NSString *BMMarkerCalloutInfoDidChangeNotification;

	[BaseType (typeof (NSObject))]
	interface BMEntity : BMMarker {

		// @required - (id)initWithCoordinate:(CLLocationCoordinate2D)coordinate bingAddressDictionary:(NSDictionary *)addressDictionary;
		[Export ("initWithCoordinate:bingAddressDictionary:")]
		IntPtr Constructor (CLLocationCoordinate2D coordinate, NSDictionary addressDictionary);

		// @property (readonly, nonatomic) NSDictionary * addressDictionary;
		[Export ("addressDictionary")]
		NSDictionary AddressDictionary { get; }

		// @property (readonly, nonatomic) NSString * addressLine;
		[Export ("addressLine")]
		string AddressLine { get; }

		// @property (readonly, nonatomic) NSString * adminDistrict;
		[Export ("adminDistrict")]
		string AdminDistrict { get; }

		// @property (readonly, nonatomic) NSString * adminDistrict2;
		[Export ("adminDistrict2")]
		string AdminDistrict2 { get; }

		// @property (readonly, nonatomic) NSString * locality;
		[Export ("locality")]
		string Locality { get; }

		// @property (readonly, nonatomic) NSString * postalCode;
		[Export ("postalCode")]
		string PostalCode { get; }

		// @property (readonly, nonatomic) NSString * countryRegion;
		[Export ("countryRegion")]
		string CountryRegion { get; }

		// @property (readonly, nonatomic) NSString * formattedAddress;
		[Export ("formattedAddress")]
		string FormattedAddress { get; }
	}

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	public partial interface BMMarker {

		// @required @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate")]
//		CLLocationCoordinate2D Coordinate { get; }
		CLLocationCoordinate2D GetCoordinate ();

		// @optional - (NSString *)title;
//		[Internal]
		[Export ("title")]
		string GetTitle ();

		// @optional - (NSString *)subtitle;
//		[Internal]
		[Export ("subtitle")]
		string GetSubtitle ();
	}

	[BaseType (typeof (BMMarkerView))]
	interface BMPushpinView {

		// @required - (id)initWithMarker:(id<BMMarker>)marker reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithMarker:reuseIdentifier:")]
		IntPtr Constructor (BMMarker marker, [NullAllowed] string reuseIdentifier);

		// @property (nonatomic) BMPushpinColor pinColor;
		[Export ("pinColor")]
		BMPushpinColor PinColor { get; set; }

		// @property (nonatomic) BOOL animatesDrop;
		[Export ("animatesDrop")]
		bool AnimatesDrop { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface BMUserLocation : BMMarker {

		// @property (readonly, nonatomic, getter = isUpdating) BOOL updating;
		[Export ("updating")]
		bool Updating { [Bind ("isUpdating")] get; }

		// @property (readonly, nonatomic) CLLocation * location;
		[Export ("location")]
		CLLocation Location { get; }

		// @property (retain, nonatomic) NSString * title;
//		[Internal]
		[Export ("setTitle:")]
		void SetTitle (string title);

		// @property (retain, nonatomic) NSString * subtitle;
//		[Internal]
		[Export ("setSubtitle:")]
		void SetSubtitle (string subtitle);
	}

	[BaseType (typeof (UIView), Delegates = new [] { "WeakDelegate" }, Events = new [] { typeof (BMMapViewDelegate)})]
	interface BMMapView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (assign, nonatomic) id<BMMapViewDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) id<BMMapViewDelegate> delegate;
		[Wrap ("WeakDelegate")]
		BMMapViewDelegate Delegate { get; set; }

		// @property (nonatomic) BMMapMode mapMode;
		[Export ("mapMode")]
		BMMapMode MapMode { get; set; }

		// @property (nonatomic) BMCoordinateRegion region;
		[Export ("region")]
		BMCoordinateRegion Region { get; set; }

		// @property (nonatomic) BOOL zoomEnabled;
		[Export ("zoomEnabled")]
		bool ZoomEnabled { get; set; }

		// @property (nonatomic) BOOL scrollEnabled;
		[Export ("scrollEnabled")]
		bool ScrollEnabled { get; set; }

		// @property (nonatomic) CLLocationCoordinate2D centerCoordinate;
		[Export ("centerCoordinate")]
		CLLocationCoordinate2D CenterCoordinate { get; set; }

		// @property (nonatomic) BOOL showsUserLocation;
		[Export ("showsUserLocation")]
		bool ShowsUserLocation { get; set; }

		// @property (readonly, nonatomic) BMUserLocation * userLocation;
		[Export ("userLocation")]
		BMUserLocation UserLocation { get; }

		// @property (readonly, nonatomic, getter = isUserLocationVisible) BOOL userLocationVisible;
		[Export ("userLocationVisible")]
		bool UserLocationVisible { [Bind ("isUserLocationVisible")] get; }

		// @property (readonly, nonatomic) NSArray * markers;
		[Export ("markers")]
		BMMarker [] Markers { get; }

		// @property (copy, nonatomic) NSArray * selectedMarkers;
		[Export ("selectedMarkers", ArgumentSemantic.Copy)]
		BMMarker [] SelectedMarkers { get; set; }

		// @property (readonly, nonatomic) CGRect markerVisibleRect;
		[Export ("markerVisibleRect")]
		CGRect MarkerVisibleRect { get; }

		// @required - (void)setRegion:(id)region animated:(BOOL)animated;
		[Export ("setRegion:animated:")]
		void SetRegion (BMCoordinateRegion region, bool animated);

		// @required - (void)setCenterCoordinate:(id)coordinate animated:(BOOL)animated;
		[Export ("setCenterCoordinate:animated:")]
		void SetCenterCoordinate (CLLocationCoordinate2D coordinate, bool animated);

		// @required - (BMCoordinateRegion)regionThatFits:(BMCoordinateRegion)region;
		[Export ("regionThatFits:")]
		BMCoordinateRegion RegionThatFits (BMCoordinateRegion region);

		// @required - (CGPoint)convertCoordinate:(id)coordinate toPointToView:(UIView *)view;
		[Export ("convertCoordinate:toPointToView:")]
		CGPoint ConvertCoordinate (CLLocationCoordinate2D coordinate, UIView view);

		// @required - (id)convertPoint:(CGPoint)point toCoordinateFromView:(UIView *)view;
		[Export ("convertPoint:toCoordinateFromView:")]
		CLLocationCoordinate2D ConvertPoint (CGPoint point, UIView view);

		// @required - (CGRect)convertRegion:(id)region toRectToView:(UIView *)view;
		[Export ("convertRegion:toRectToView:")]
		CGRect ConvertRegion (BMCoordinateRegion region, UIView view);

		// @required - (id)convertRect:(CGRect)rect toRegionFromView:(UIView *)view;
		[Export ("convertRect:toRegionFromView:")]
		BMCoordinateRegion ConvertRect (CGRect rect, UIView view);

		// @required - (void)addMarker:(id)marker;
		[Export ("addMarker:")]
		void AddMarker (BMMarker marker);

		// @required - (void)addMarkers:(NSArray *)markers;
		[Export ("addMarkers:")]
		void AddMarkers (BMMarker [] markers);

		// @required - (void)removeMarker:(id)marker;
		[Export ("removeMarker:")]
		void RemoveMarker (BMMarker marker);

		// @required - (void)removeMarkers:(NSArray *)markers;
		[Export ("removeMarkers:")]
		void RemoveMarkers (BMMarker [] markers);

		// @required - (id)viewForMarker:(id)marker;
		[Export ("viewForMarker:")]
		BMMarkerView ViewForMarker (BMMarker marker);

		// @required - (id)dequeueReusableMarkerViewWithIdentifier:(NSString *)identifier;
		[Export ("dequeueReusableMarkerViewWithIdentifier:")]
		BMMarkerView DequeueReusableMarkerView ( [NullAllowed] string identifier);

		// @required - (void)selectMarker:(id)marker animated:(BOOL)animated;
		[Export ("selectMarker:animated:")]
		void SelectMarker (BMMarker marker, bool animated);

		// @required - (void)deselectMarker:(id)marker animated:(BOOL)animated;
		[Export ("deselectMarker:animated:")]
		void DeselectMarker (BMMarker marker, bool animated);
	}

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface BMMapViewDelegate {

		// @optional - (void)mapView:(BMMapView *)mapView regionWillChangeAnimated:(BOOL)animated;
		[Export ("mapView:regionWillChangeAnimated:")]
		[EventArgs ("BMMapViewRegionChage")]
		void RegionChanging (BMMapView mapView, bool animated);

		// @optional - (void)mapView:(BMMapView *)mapView regionDidChangeAnimated:(BOOL)animated;
		[Export ("mapView:regionDidChangeAnimated:")]
		[EventArgs ("BMMapViewRegionChage")]
		void RegionChanged (BMMapView mapView, bool animated);

		// @optional - (void)mapViewWillStartLoadingMap:(BMMapView *)mapView;
		[Export ("mapViewWillStartLoadingMap:")]
		[EventArgs ("BMMapViewLoading")]
		void Loading (BMMapView mapView);

		// @optional - (void)mapViewDidFinishLoadingMap:(BMMapView *)mapView;
		[Export ("mapViewDidFinishLoadingMap:")]
		[EventArgs ("BMMapViewLoading")]
		void Loaded (BMMapView mapView);

		// @optional - (void)mapViewDidFailLoadingMap:(BMMapView *)mapView withError:(NSError *)error;
		[Export ("mapViewDidFailLoadingMap:withError:")]
		[EventArgs ("BMMapViewError")]
		void LoadingFailed (BMMapView mapView, NSError error);

		// @optional - (id)mapView:(BMMapView *)mapView viewForMarker:(id)marker;
		[Export ("mapView:viewForMarker:")]
		[DelegateName ("BMMapViewGetMarkerViewCallback"), DefaultValue ("BMMapView.GetDefaultMarkerView (marker)")]
		BMMarkerView GetMarkerView (BMMapView mapView, BMMarker marker);

		// @optional - (void)mapView:(BMMapView *)mapView didAddMarkerViews:(NSArray *)views;
		[Export ("mapView:didAddMarkerViews:")]
		[EventArgs ("BMMapViewAddMarkerView")]
		void AddedMarkerViews (BMMapView mapView, UIView [] views);

		// @optional - (void)mapView:(BMMapView *)mapView markerView:(id)view calloutAccessoryControlTapped:(UIControl *)control;
		[Export ("mapView:markerView:calloutAccessoryControlTapped:")]
		[EventArgs ("BMMapViewMarkerViewCalloutTapped")]
		void MarkerViewCalloutAccessoryTapped (BMMapView mapView, BMMarkerView view, UIControl control);
	}

	[BaseType (typeof (UIView))]
	interface BMMarkerView {

		// @required - (id)initWithMarker:(id<BMMarker>)marker reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithMarker:reuseIdentifier:")]
		IntPtr Constructor (BMMarker marker, [NullAllowed] string reuseIdentifier);

		// @property (readonly, nonatomic) NSString * reuseIdentifier;
		[Export ("reuseIdentifier")]
		string ReuseIdentifier { get; }

		// @property (retain, nonatomic) id<BMMarker> marker;
		[Export ("marker", ArgumentSemantic.Retain)]
		BMMarker Marker { get; set; }

		// @property (retain, nonatomic) UIImage * image;
		[Export ("image", ArgumentSemantic.Retain)]
		[NullAllowed]
		UIImage Image { get; set; }

		// @property (nonatomic) CGPoint centerOffset;
		[Export ("centerOffset")]
		CGPoint CenterOffset { get; set; }

		// @property (nonatomic) CGPoint calloutOffset;
		[Export ("calloutOffset")]
		CGPoint CalloutOffset { get; set; }

		// @property (nonatomic, getter = isEnabled) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// @property (nonatomic, getter = isSelected) BOOL selected;
		[Export ("selected")]
		bool Selected { [Bind ("isSelected")] get; set; }

		// @property (nonatomic) BOOL canShowCallout;
		[Export ("canShowCallout")]
		bool CanShowCallout { get; set; }

		// @property (retain, nonatomic) UIView * calloutAccessoryView1;
		[Export ("calloutAccessoryView1", ArgumentSemantic.Retain)]
		[NullAllowed]
		UIView CalloutAccessoryView1 { get; set; }

		// @property (retain, nonatomic) UIView * calloutAccessoryView2;
		[Export ("calloutAccessoryView2", ArgumentSemantic.Retain)]
		[NullAllowed]
		UIView CalloutAccessoryView2 { get; set; }

		// @required - (void)prepareForReuse;
		[Export ("prepareForReuse")]
		void PrepareForReuse ();

		// @required - (void)setSelected:(BOOL)selected animated:(BOOL)animated;
		[Export ("setSelected:animated:")]
		void SetSelected (bool selected, bool animated);
	}

	[BaseType (
		typeof (NSObject), 
		Delegates = new [] { "WeakDelegate" },
		Events = new [] { typeof (BMReverseGeocoderDelegate)})]
	interface BMReverseGeocoder {

		// @required - (id)initWithCoordinate:(CLLocationCoordinate2D)coordinate;
		[Export ("initWithCoordinate:")]
		IntPtr Constructor (CLLocationCoordinate2D coordinate);

		// @property (assign, nonatomic) id<BMReverseGeocoderDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) id<BMReverseGeocoderDelegate> delegate;
		[Wrap ("WeakDelegate")]
		BMReverseGeocoderDelegate Delegate { get; set; }

		// @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		// @property (readonly, nonatomic) BMEntity * entity;
		[Export ("entity")]
		BMEntity Entity { get; }

		// @property (readonly, nonatomic, getter = isQuerying) BOOL querying;
		[Export ("querying")]
		bool Querying { [Bind ("isQuerying")] get; }

		// @required - (void)start;
		[Export ("start")]
		void Start ();

		// @required - (void)cancel;
		[Export ("cancel")]
		void Cancel ();
	}

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface BMReverseGeocoderDelegate {

		// @required - (void)reverseGeocoder:(BMReverseGeocoder *)geocoder didFindEntity:(BMEntity *)entity;
		[Export ("reverseGeocoder:didFindEntity:")]
		[Abstract]
		[EventArgs("BMReverseGeocoderFoundEntity")]
		void EntityFound (BMReverseGeocoder geocoder, BMEntity entity);

		// @required - (void)reverseGeocoder:(BMReverseGeocoder *)geocoder didFailWithError:(NSError *)error;
		[Export ("reverseGeocoder:didFailWithError:")]
		[Abstract]
		[EventArgs("BMReverseGeocoderFailed")]
		void Failed (BMReverseGeocoder geocoder, NSError error);
	}

}

