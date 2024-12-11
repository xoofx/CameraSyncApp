using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.WMDM
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("923E5249-8731-4c5b-9B1C-B8B60B6E46AF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IWMDeviceManager2 : IWMDeviceManager 
    {
        void GetDeviceFromCanonicalName(
            string pwszCanonicalName,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWMDMDevice>))] out IWMDMDevice ppDevice);
        
        void EnumDevices2(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWMDMEnumDevice>))] out IWMDMEnumDevice ppEnumDevice);
        
        void Reinitialize();
        
    }
}
