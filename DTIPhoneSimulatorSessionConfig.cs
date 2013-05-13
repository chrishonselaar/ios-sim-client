using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace IosSimulatorClientBinding
{
    [Register("DTiPhoneSimulatorSessionConfig", true)]
    public class DtiPhoneSimulatorSessionConfig : NSObject
    {
        #region selector handles
        private static readonly IntPtr SelSimulatedApplicationStdErrPathHandle = Selector.GetHandle("simulatedApplicationStdErrPath");
        private static readonly IntPtr SelSetSimulatedApplicationStdErrPathHandle = Selector.GetHandle("setSimulatedApplicationStdErrPath:");
        private static readonly IntPtr SelSimulatedApplicationStdOutPathHandle = Selector.GetHandle("simulatedApplicationStdOutPath");
        private static readonly IntPtr SelSetSimulatedApplicationStdOutPathHandle = Selector.GetHandle("setSimulatedApplicationStdOutPath:");
        private static readonly IntPtr SelSimulatedApplicationLaunchEnvironmentHandle = Selector.GetHandle("simulatedApplicationLaunchEnvironment");
        private static readonly IntPtr SelSetSimulatedApplicationLaunchEnvironmentHandle = Selector.GetHandle("setSimulatedApplicationLaunchEnvironment:");
        private static readonly IntPtr SelSimulatedApplicationLaunchArgsHandle = Selector.GetHandle("simulatedApplicationLaunchArgs");
        private static readonly IntPtr SelSetSimulatedApplicationLaunchArgsHandle = Selector.GetHandle("setSimulatedApplicationLaunchArgs:");
        private static readonly IntPtr SelApplicationToSimulateOnStartHandle = Selector.GetHandle("applicationToSimulateOnStart");
        private static readonly IntPtr SelSetApplicationToSimulateOnStartHandle = Selector.GetHandle("setApplicationToSimulateOnStart:");
        private static readonly IntPtr SelSimulatedSystemRootHandle = Selector.GetHandle("simulatedSystemRoot");
        private static readonly IntPtr SelSetSimulatedSystemRootHandle = Selector.GetHandle("setSimulatedSystemRoot:");
        private static readonly IntPtr SelSimulatedApplicationShouldWaitForDebuggerHandle = Selector.GetHandle("simulatedApplicationShouldWaitForDebugger");
        private static readonly IntPtr SelSetSimulatedApplicationShouldWaitForDebuggerHandle = Selector.GetHandle("setSimulatedApplicationShouldWaitForDebugger:");
        private static readonly IntPtr SelLocalizedClientNameHandle = Selector.GetHandle("localizedClientName");
        private static readonly IntPtr SelSetLocalizedClientNameHandle = Selector.GetHandle("setLocalizedClientName:");
        private static readonly IntPtr SelSetSimulatedDeviceFamilyHandle = Selector.GetHandle("setSimulatedDeviceFamily:");
        private static readonly IntPtr ClassPtr = Class.GetHandle("DTiPhoneSimulatorSessionConfig");
        #endregion

        [Export("init")]
        public DtiPhoneSimulatorSessionConfig() : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend(Handle, Selector.Init);
        }

        [Export("initWithCoder:")]
        public DtiPhoneSimulatorSessionConfig(NSCoder coder) : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend_IntPtr(Handle, Selector.InitWithCoder, coder.Handle);
        }
        public DtiPhoneSimulatorSessionConfig(NSObjectFlag t) : base(t) { }
        public DtiPhoneSimulatorSessionConfig(IntPtr handle) : base(handle) { }

        public virtual string SimulatedApplicationStdErrPath
        {
            [Export("simulatedApplicationStdErrPath")]
            get
            {
                return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSimulatedApplicationStdErrPathHandle)).ToString();
            }

            [Export("setSimulatedApplicationStdErrPath:")]
            set
            {
				if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSimulatedApplicationStdErrPathHandle, new NSString(value).Handle);
            }
        }

        public virtual string SimulatedApplicationStdOutPath
        {
            [Export("simulatedApplicationStdOutPath")]
            get
            {
                return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSimulatedApplicationStdOutPathHandle)).ToString();
            }

            [Export("setSimulatedApplicationStdOutPath:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSimulatedApplicationStdOutPathHandle, new NSString(value).Handle);
            }
        }


        public virtual NSDictionary SimulatedApplicationLaunchEnvironment
        {
            [Export("simulatedApplicationLaunchEnvironment")]
            get
            {
                return (NSDictionary)(Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSimulatedApplicationLaunchEnvironmentHandle)));
            }

            [Export("setSimulatedApplicationLaunchEnvironment:")]
            set
            {
                //if (value == null) throw new ArgumentNullException ("value"); // TODO: send zero pointer for null value, or throw exception?
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSimulatedApplicationLaunchEnvironmentHandle, value == null ? IntPtr.Zero : value.Handle);
            }
        }

        public virtual NSArray SimulatedApplicationLaunchArgs
        {
            [Export("simulatedApplicationLaunchArgs")]
            get
            {
                return (NSArray)(Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSimulatedApplicationLaunchArgsHandle)));
            }

            [Export("setSimulatedApplicationLaunchArgs:")]
            set
            {
                //if (value == null) throw new ArgumentNullException("value"); // TODO: send zero pointer for null value, or throw exception?
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSimulatedApplicationLaunchArgsHandle, value == null ? IntPtr.Zero : value.Handle);
            }
        }

        public virtual DTiPhoneSimulatorApplicationSpecifier ApplicationToSimulateOnStart
        {
            [Export("applicationToSimulateOnStart")]
            get
            {
                return (DTiPhoneSimulatorApplicationSpecifier)Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelApplicationToSimulateOnStartHandle));
            }

            [Export("setApplicationToSimulateOnStart:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetApplicationToSimulateOnStartHandle, value.Handle);
            }
        }

        public virtual DtiPhoneSimulatorSystemRoot SimulatedSystemRoot
        {
            [Export("simulatedSystemRoot")]
            get
            {
                return (DtiPhoneSimulatorSystemRoot)Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSimulatedSystemRootHandle));
            }

            [Export("setSimulatedSystemRoot:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSimulatedSystemRootHandle, value.Handle);
            }
        }

        public virtual bool SimulatedApplicationShouldWaitForDebugger
        {
            [Export("simulatedApplicationShouldWaitForDebugger")] get { return Messaging.bool_objc_msgSend(Handle, SelSimulatedApplicationShouldWaitForDebuggerHandle); }

            [Export("setSimulatedApplicationShouldWaitForDebugger:")] set { Messaging.void_objc_msgSend_bool(Handle, SelSetSimulatedApplicationShouldWaitForDebuggerHandle, value); }
        }

        public virtual string LocalizedClientName
        {
            [Export("localizedClientName")] get { return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelLocalizedClientNameHandle)).ToString(); }

            [Export("setLocalizedClientName:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetLocalizedClientNameHandle, new NSString(value).Handle);
            }
        }


        public virtual NSNumber SimulatedDeviceFamily
        {
            [Export("setSimulatedDeviceFamily:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSimulatedDeviceFamilyHandle, value.Handle);
            }
        }
    }
}