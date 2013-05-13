using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using IosSimulatorClientBinding;

namespace SimulatorLaunchSample
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;

		public AppDelegate ()
		{
		}

		public override void FinishedLaunching (NSObject notification)
		{
			mainWindowController = new MainWindowController ();
			mainWindowController.Window.MakeKeyAndOrderFront (this);

			StartSim(false, "/Users/chrishonselaar/Projects/TestRecording/TestRecording/bin/iPhoneSimulator/Debug/TestRecording.app");
		}
				
		private bool StartSim(bool iPad, string appPath)
		{
			var appSpec = DTiPhoneSimulatorApplicationSpecifier.SpecifierWithApplicationPath (appPath);
			var sdkRoot = DtiPhoneSimulatorSystemRoot.DefaultRoot;

			var config = new DtiPhoneSimulatorSessionConfig ();
			config.ApplicationToSimulateOnStart = appSpec;
			config.SimulatedSystemRoot = sdkRoot;
			config.SimulatedApplicationShouldWaitForDebugger = false;
			config.LocalizedClientName = new NSString("ios-sim2");
			config.SimulatedDeviceFamily = iPad ? 2 : 1;

			var session = new DtiPhoneSimulatorSession ();
			NSError error;
			return session.RequestStartWithConfig (config, 30, out error);
		}
	}
}

