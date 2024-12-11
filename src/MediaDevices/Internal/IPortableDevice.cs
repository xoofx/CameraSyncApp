using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDevice : IComObject
    {
        void Open(
            string pszPnPDeviceID,
            IPortableDeviceValues pClientInfo);

        void SendCommand(
            uint dwFlags,
            IPortableDeviceValues pParameters,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppResults);

        void Content(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceContent>))] out IPortableDeviceContent ppContent);

        void Capabilities(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceCapabilities>))] out IPortableDeviceCapabilities ppCapabilities);

        void Cancel();

        void Close();

        void Advise(
            uint dwFlags,
            IPortableDeviceEventCallback pCallback,
            IPortableDeviceValues? pParameters,
            out string ppszCookie);

        void Unadvise(
            string pszCookie);

        void GetPnPDeviceID(
            out string ppszPnPDeviceID);
    }
}
