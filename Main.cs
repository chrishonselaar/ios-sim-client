using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace SimulatorLaunchSample
{
	class MainClass
	{
		static void Main (string [] args)
		{
			Dlfcn.dlopen ("iPhoneSimulatorRemoteClient.framework/iPhoneSimulatorRemoteClient", 0);

			NSApplication.Init ();
			NSApplication.Main (args);
		}
	}
}	

