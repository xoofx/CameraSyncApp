using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    internal static class PortableDevicePropVariantCollection
    {
        public static readonly Guid ClsId = new("08A99E2F-6D6D-4B80-AF5A-BAF2BCBE4CB9");

        public static IPortableDevicePropVariantCollection New() => ComHelper.ActivateClass<IPortableDevicePropVariantCollection>(ClsId);
    }
}
