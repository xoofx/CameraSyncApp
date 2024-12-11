using MediaDevices.Internal;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.WMDM
{

    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17763.0\um\mswmdm.h

    [GeneratedComInterface]
    [Guid("1DCB3A00-33ED-11d3-8470-00C04F79DBC0")]    
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IWMDeviceManager : IComObject
    {
        void GetRevision(out uint pdwRevision);

        void GetDeviceCount(out uint pdwCount);

        void EnumDevices([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWMDMEnumDevice>))] out IWMDMEnumDevice ppEnumDevice);
    }
}
