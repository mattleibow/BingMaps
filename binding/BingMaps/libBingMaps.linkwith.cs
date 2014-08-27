using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith (
	"libBingMaps.a", 
	LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Simulator, 
	ForceLoad = true,
	Frameworks = "CoreData CoreLocation OpenGLES QuartzCore SystemConfiguration",
	LinkerFlags = "-lz -lxml2")]
