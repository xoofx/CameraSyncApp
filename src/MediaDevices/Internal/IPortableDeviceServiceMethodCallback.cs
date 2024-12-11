using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("C424233C-AFCE-4828-A756-7ED7A2350083")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceServiceMethodCallback : IComObject
    {
        void OnComplete(
            int hrStatus, 
            IPortableDeviceValues pResults);
    }
}
