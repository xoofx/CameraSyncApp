using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("A8792A31-F385-493C-A893-40F64EB45F6E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceEventCallback : IComObject
    {
        void OnEvent(
            IPortableDeviceValues pEventParameters);
    }
}
