using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    internal static class PortableDeviceValues
    {
        private static readonly Guid ClsId = new Guid("0C15D503-D017-47CE-9016-7B3F978721CC");

        public static IPortableDeviceValues New() => ComHelper.ActivateClass<IPortableDeviceValues>(ClsId);
    }
}
