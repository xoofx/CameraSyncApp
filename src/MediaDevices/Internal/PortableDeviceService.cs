using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    internal static class PortableDeviceService
    {
        private static readonly Guid ClsId = new("EF5DB4C2-9312-422C-9152-411CD9C4DD84");

        public static IPortableDeviceService New() => ComHelper.ActivateClass<IPortableDeviceService>(ClsId);
    }
}
