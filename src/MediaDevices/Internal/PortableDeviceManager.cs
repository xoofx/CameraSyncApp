using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    internal static class PortableDeviceManager
    {
        private static readonly Guid ClsId = new("0af10cec-2ecd-4b92-9581-34f6ae0637f3");

        public static IPortableDeviceManager New() => ComHelper.ActivateClass<IPortableDeviceManager>(ClsId);

    }
}
