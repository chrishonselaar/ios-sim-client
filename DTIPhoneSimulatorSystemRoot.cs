using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace IosSimulatorClientBinding
{
    [Register("DTiPhoneSimulatorSystemRoot", true)]
    public class DtiPhoneSimulatorSystemRoot : NSObject
    {
        #region selector handles
        private static readonly IntPtr SelDefaultRootHandle = Selector.GetHandle("defaultRoot");
        private static readonly IntPtr SelKnownRootsHandle = Selector.GetHandle("knownRoots");
        private static readonly IntPtr SelSdkDisplayNameHandle = Selector.GetHandle("sdkDisplayName");
        private static readonly IntPtr SelSetSdkDisplayNameHandle = Selector.GetHandle("setSdkDisplayName:");
        private static readonly IntPtr SelSdkVersionHandle = Selector.GetHandle("sdkVersion");
        private static readonly IntPtr SelSetSdkVersionHandle = Selector.GetHandle("setSdkVersion:");
        private static readonly IntPtr SelSdkRootPathHandle = Selector.GetHandle("sdkRootPath");
        private static readonly IntPtr SelSetSdkRootPathHandle = Selector.GetHandle("setSdkRootPath:");
        private static readonly IntPtr SelRootWithSdkPathHandle = Selector.GetHandle("rootWithSDKPath:");
        private static readonly IntPtr SelRootWithSdkVersionHandle = Selector.GetHandle("rootWithSDKVersion:");
        private static readonly IntPtr SelInitWithSdkPathHandle = Selector.GetHandle("initWithSDKPath:");
        private static readonly IntPtr ClassPtr = Class.GetHandle("DTiPhoneSimulatorSystemRoot");
        #endregion

        [Export("init")]
        public DtiPhoneSimulatorSystemRoot() : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend(Handle, Selector.Init);
        }

        [Export("initWithCoder:")]
        public DtiPhoneSimulatorSystemRoot(NSCoder coder) : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend_IntPtr(Handle, Selector.InitWithCoder, coder.Handle);
        }
        public DtiPhoneSimulatorSystemRoot(NSObjectFlag t) : base(t) { }
        public DtiPhoneSimulatorSystemRoot(IntPtr handle) : base(handle) { }

        [Export("rootWithSDKPath:")]
        public static NSObject RootWithSdkpAth(NSObject fp8)
        {
            if (fp8 == null) throw new ArgumentNullException("fp8");
            return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend_IntPtr(ClassPtr, SelRootWithSdkPathHandle, fp8.Handle));
        }

        [Export("rootWithSDKVersion:")]
        public static NSObject RootWithSdkvErsion(NSObject fp8)
        {
            if (fp8 == null) throw new ArgumentNullException("fp8");
            return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend_IntPtr(ClassPtr, SelRootWithSdkVersionHandle, fp8.Handle));
        }

        [Export("initWithSDKPath:")]
        public DtiPhoneSimulatorSystemRoot(NSObject fp8) : base(NSObjectFlag.Empty)
        {
            if (fp8 == null) throw new ArgumentNullException("fp8");
            Handle = Messaging.IntPtr_objc_msgSend_IntPtr(Handle, SelInitWithSdkPathHandle, fp8.Handle);
        }

        public static DtiPhoneSimulatorSystemRoot DefaultRoot
        {
            [Export("defaultRoot")]
            get { return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(ClassPtr, SelDefaultRootHandle)) as DtiPhoneSimulatorSystemRoot; }
        }

        public virtual NSObject[] KnownRoots
        {
            [Export("knownRoots")] get { return NSArray.ArrayFromHandle<NSObject>(Messaging.IntPtr_objc_msgSend(Handle, SelKnownRootsHandle)); }
        }

        public virtual string SdkDisplayName
        {
            [Export("sdkDisplayName")] get { return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSdkDisplayNameHandle)).ToString(); }

            [Export("setSdkDisplayName:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSdkDisplayNameHandle, new NSString(value).Handle);
            }
        }

        public virtual string SdkVersion
        {
            [Export("sdkVersion")] get { return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSdkVersionHandle)).ToString(); }

            [Export("setSdkVersion:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSdkVersionHandle, new NSString(value).Handle);
            }
        }

        public virtual string SdkRootPath
        {
            [Export("sdkRootPath")] get { return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSdkRootPathHandle)).ToString(); }

            [Export("setSdkRootPath:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSdkRootPathHandle, new NSString(value).Handle);
            }
        }
    }
}