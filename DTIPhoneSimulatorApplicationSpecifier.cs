using System;
using System.Runtime.InteropServices;
using MonoMac;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace IosSimulatorClientBinding
{
    [Register("DTiPhoneSimulatorApplicationSpecifier", true)]
	public class DTiPhoneSimulatorApplicationSpecifier : NSObject
    {
        #region selector handles
        private static readonly IntPtr SelBundleIdHandle = Selector.GetHandle("bundleID");
        private static readonly IntPtr SelSetBundleIdHandle = Selector.GetHandle("setBundleID:");
        private static readonly IntPtr SelAppPathHandle = Selector.GetHandle("appPath");
        private static readonly IntPtr SelSetAppPathHandle = Selector.GetHandle("setAppPath:");
        private static readonly IntPtr SelSpecifierWithApplicationPathHandle = Selector.GetHandle("specifierWithApplicationPath:");
        private static readonly IntPtr SelSpecifierWithApplicationBundleIdentifierHandle = Selector.GetHandle("specifierWithApplicationBundleIdentifier:");
        private static readonly IntPtr ClassPtr = Class.GetHandle("DTiPhoneSimulatorApplicationSpecifier");
        #endregion

		public override IntPtr ClassHandle { get { return ClassPtr; } }

        [Export("init")]
        public DTiPhoneSimulatorApplicationSpecifier() : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend(Handle, Selector.Init);
        }

        [Export("initWithCoder:")]
        public DTiPhoneSimulatorApplicationSpecifier(NSCoder coder) : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend_IntPtr(Handle, Selector.InitWithCoder, coder.Handle);
        }
        public DTiPhoneSimulatorApplicationSpecifier(NSObjectFlag t) : base(t) {}
        public DTiPhoneSimulatorApplicationSpecifier(IntPtr handle) : base(handle) {}

        public virtual string BundleId
        {
            [Export("bundleID")] get { return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(Handle, SelBundleIdHandle)); }

            [Export("setBundleID:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                var nsvalue = NSString.CreateNative(value);
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetBundleIdHandle, nsvalue);
                NSString.ReleaseNative(nsvalue);
            }
        }

        public virtual string AppPath
        {
            [Export("appPath")] get { return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(Handle, SelAppPathHandle)); }

            [Export("setAppPath:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                var nsvalue = NSString.CreateNative(value);
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetAppPathHandle, nsvalue);
                NSString.ReleaseNative(nsvalue);
            }
        }

        [Export("specifierWithApplicationPath:")]
        public static DTiPhoneSimulatorApplicationSpecifier SpecifierWithApplicationPath(string appPath)
        {
            if (appPath == null) throw new ArgumentNullException("appPath");
            var nsappPath = NSString.CreateNative(appPath);
			var ret = Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend_IntPtr(ClassPtr, SelSpecifierWithApplicationPathHandle, nsappPath));
            NSString.ReleaseNative(nsappPath);
			return ret as DTiPhoneSimulatorApplicationSpecifier;
        }

        [Export("specifierWithApplicationBundleIdentifier:")]
        public static DTiPhoneSimulatorApplicationSpecifier SpecifierWithApplicationBundleIdentifier(string bundleID)
        {
            if (bundleID == null) throw new ArgumentNullException("bundleID");
            var nsbundleId = NSString.CreateNative(bundleID);
            var ret = Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend_IntPtr(ClassPtr, SelSpecifierWithApplicationBundleIdentifierHandle, nsbundleId));
            NSString.ReleaseNative(nsbundleId);
			return ret as DTiPhoneSimulatorApplicationSpecifier;
        }
    }
}