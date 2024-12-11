using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("A1567595-4C2F-4574-A6FA-ECEF917B9A40")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceManager : IComObject
    {
        void GetDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? pPnPDeviceIDs,
            ref uint pcPnPDeviceIDs);

        void RefreshDeviceList();

        void GetDeviceFriendlyName(
            string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPArray)] char[] pDeviceFriendlyName,
            ref uint pcchDeviceFriendlyName);

        void GetDeviceDescription(
            string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPArray)] char[] pDeviceDescription,
            ref uint pcchDeviceDescription);

        void GetDeviceManufacturer(
            string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPArray)] char[] pDeviceManufacturer,
            ref uint pcchDeviceManufacturer);

        void GetDeviceProperty(
            string pszPnPDeviceID,
            string pszDevicePropertyName,
            ref byte pData,
            ref uint pcbData,
            ref uint pdwType);

        void GetPrivateDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)]string[]? pPnPDeviceIDs,
            ref uint pcPnPDeviceIDs);
    }
}
