using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    internal static class PortableDeviceKeyCollection
    {
        private static readonly Guid ClsId = new Guid("DE2D022D-2480-43BE-97F0-D1FA2CF98F4F");

        public static IPortableDeviceKeyCollection New() => ComHelper.ActivateClass<IPortableDeviceKeyCollection>(ClsId);
    }
}
