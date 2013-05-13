# iOS Simulator Client Binding for MonoMac

A MonoMac binding for the private XCode iPhoneSimulatorRemoteClient framework, as used by PhoneGap, Appcelerator, Xamarin (presumably), XCode and others. This framework allows you to launch and connect to the iOS Simulator, deploy .app bundles on it, run them, supply arguments and plist values to them and monitor their output. You can also retreive and select available iOS SDK versions for the Simulator. 
Perfect for automated functional testing, development tools etc.

## Status
The binding is functional - just fill in your own iOS .app bundle path in AppDelegate.cs, run the project and you should see it launch in the iOS simulator.
The only thing not covered by the binding yet is DTiPhoneSimulatorSessionDelegate. This provides additional error reporting. I will get this in as well soon.
The binding is not structured as a separate project yet. For now you can just copy-paste the 4 'DT*.cs' files into your project (and apply the steps below). If you want to help out to restructure to a separate assembly, please let me know!! Someone with a little more in-depth MonoMac binding knowledge should be able to do it in 5 minutes or less.

## Binding non-core Objective C frameworks
As you can also see in this project, the two main steps for binding frameworks like this are:

1. set a search path for the framework (and its referenced frameworks if any) - this can be done by adding an 'LSEnvironment' key to the Info.plist, and under that add a dict value as follows:

  <dict>
    <key>DYLD_FRAMEWORK_PATH</key>
		<string>/Applications/Xcode.app/Contents/Developer/Platforms/iPhoneSimulator.platform/Developer/Library/PrivateFrameworks/:/Applications/Xcode.app/Contents/OtherFrameworks/</string>
  </dict>

where the string value is a colon-separated list of search paths.

2. Dynamically link the framework by calling `MonoMac.ObjCRuntime.Dlfcn.dlopen()` with the relative path to the binary library file within the framework directory. This needs to be called BEFORE `NSApplication.Init()`. See Main.cs for an example.

## Additional reading
A simple open source Objective C command line client using this framework is available on GitHub:
https://github.com/phonegap/ios-sim
It has some additional functionality to select retina/iPhone5 mode, dump the app output, and a hook to attach a debugger.
