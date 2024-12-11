using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.WMDM
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("af185c41-100d-46ed-be2e-9ce8c44594ef")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IWMDeviceManager3  : IWMDeviceManager2
    {
        void SetDeviceEnumPreference(
            uint dwEnumPref);
    }
}
