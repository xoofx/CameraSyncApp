using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    internal static class PortableDevice
    {
        private static readonly Guid ClsId = new("728A21C5-3D9E-48D7-9810-864848F0F404");

        public static IPortableDevice New() => ComHelper.ActivateClass<IPortableDevice>(ClsId);
    }
}
