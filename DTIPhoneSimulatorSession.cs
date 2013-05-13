using System;
using System.Runtime.InteropServices;
using MonoMac;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace IosSimulatorClientBinding
{
    [Register("DTiPhoneSimulatorSession", true)]
    public class DtiPhoneSimulatorSession : NSObject
    {
        #region selector handles
        private static readonly IntPtr SelSessionConfigHandle = Selector.GetHandle("sessionConfig");
        private static readonly IntPtr SelSetSessionConfigHandle = Selector.GetHandle("setSessionConfig:");
        private static readonly IntPtr SelTimeoutTimerHandle = Selector.GetHandle("timeoutTimer");
        private static readonly IntPtr SelSetTimeoutTimerHandle = Selector.GetHandle("setTimeoutTimer:");
        private static readonly IntPtr SelSessionLifecycleProgressHandle = Selector.GetHandle("sessionLifecycleProgress");
        private static readonly IntPtr SelSetSessionLifecycleProgressHandle = Selector.GetHandle("setSessionLifecycleProgress:");
        private static readonly IntPtr SelSimulatedApplicationPidHandle = Selector.GetHandle("simulatedApplicationPID");
        private static readonly IntPtr SelSetSimulatedApplicationPidHandle = Selector.GetHandle("setSimulatedApplicationPID:");
        private static readonly IntPtr SelUuidHandle = Selector.GetHandle("uuid");
        private static readonly IntPtr SelSetUuidHandle = Selector.GetHandle("setUuid:");
        private static readonly IntPtr SelRequestStartWithConfigTimeoutErrorHandle = Selector.GetHandle("requestStartWithConfig:timeout:error:");
        private static readonly IntPtr SelRequestEndWithTimeoutHandle = Selector.GetHandle("requestEndWithTimeout:");
        private static readonly IntPtr ClassPtr = Class.GetHandle("DTiPhoneSimulatorSession");
        #endregion

        [Export("init")]
        public DtiPhoneSimulatorSession() : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend(Handle, Selector.Init);
        }

        [Export("initWithCoder:")]
        public DtiPhoneSimulatorSession(NSCoder coder) : base(NSObjectFlag.Empty)
        {
            Handle = Messaging.IntPtr_objc_msgSend_IntPtr(Handle, Selector.InitWithCoder, coder.Handle);
        }
        public DtiPhoneSimulatorSession(NSObjectFlag t) : base(t) { }
        public DtiPhoneSimulatorSession(IntPtr handle) : base(handle) { }

        [Export("requestStartWithConfig:timeout:error:")]
        public virtual bool RequestStartWithConfig(DtiPhoneSimulatorSessionConfig config, Double timeout, out NSError outError)
        {
            if (config == null) throw new ArgumentNullException("config");
            var outErrorPtr = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(outErrorPtr, 0);
            var ret = Messaging.Boolean_objc_msgSend_IntPtr_Double_IntPtr(Handle, SelRequestStartWithConfigTimeoutErrorHandle, config.Handle, timeout, outErrorPtr);
            var outErrorValue = Marshal.ReadIntPtr(outErrorPtr);
            outError = outErrorValue != IntPtr.Zero ? (NSError) Runtime.GetNSObject(outErrorValue) : null;
            Marshal.FreeHGlobal(outErrorPtr);
            return ret;
        }

        [Export("requestEndWithTimeout:")]
        public virtual void RequestEndWithTimeout(Double timeout)
        {
            Messaging.void_objc_msgSend_Double(Handle, SelRequestEndWithTimeoutHandle, timeout);
        }

        public virtual DtiPhoneSimulatorSessionConfig SessionConfig
        {
            [Export("sessionConfig")]
            get { return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSessionConfigHandle)) as DtiPhoneSimulatorSessionConfig; }

            [Export("setSessionConfig:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSessionConfigHandle, value.Handle);
            }
        }

        public virtual NSObject TimeoutTimer
        {
            [Export("timeoutTimer")]
            get
            {
                return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelTimeoutTimerHandle));
            }

            [Export("setTimeoutTimer:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetTimeoutTimerHandle, value.Handle);
            }
        }

        public virtual int SessionLifecycleProgress
        {
            [Export("sessionLifecycleProgress")] get { return Messaging.int_objc_msgSend(Handle, SelSessionLifecycleProgressHandle); }

            [Export("setSessionLifecycleProgress:")] set { Messaging.void_objc_msgSend_int(Handle, SelSetSessionLifecycleProgressHandle, value); }
        }

        public virtual NSObject SimulatedApplicationPid
        {
            [Export("simulatedApplicationPID")]
            get
            {
                return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelSimulatedApplicationPidHandle));
            }

            [Export("setSimulatedApplicationPID:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetSimulatedApplicationPidHandle, value.Handle);
            }
        }

        public virtual string Uuid
        {
            [Export("uuid")]
            get
            {
                return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(Handle, SelUuidHandle)).ToString();
            }

            [Export("setUuid:")]
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Messaging.void_objc_msgSend_IntPtr(Handle, SelSetUuidHandle, new NSString(value).Handle);
            }
        }
    }
}