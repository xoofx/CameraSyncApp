using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("a8abc4e9-a84a-47a9-80b3-c5d9b172a961")]  
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceServiceManager : IComObject
    {
        void GetDeviceServices(
            string pszPnPDeviceID,
            in Guid guidServiceCategory,
            //[Out, In, MarshalAs(UnmanagedType.LPWStr)] ref string[] pServices,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)]string[]? pServices,
            ref uint pcServices);
        
        void GetDeviceForService(
            string pszPnPServiceID,
            out string ppszPnPDeviceID);
        
    }
}
