using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{

    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("D3BD3A44-D7B5-40A9-98B7-2FA4D01DEC08")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceService : IComObject
    {
        void Open(
            string pszPnPServiceID,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] IPortableDeviceValues pClientInfo);

        void Capabilities(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceServiceCapabilities>))] out IPortableDeviceServiceCapabilities ppCapabilities);

        void Content(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceContent2>))] out IPortableDeviceContent2 ppContent);

        void Methods(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceServiceMethods>))] out IPortableDeviceServiceMethods ppMethods);

        void Cancel();

        void Close();

        void GetServiceObjectID(
            out string ppszServiceObjectID);

        void GetPnPServiceID(
            out string ppszPnPServiceID);

        void Advise(
            uint dwFlags, 
            IPortableDeviceEventCallback pCallback, 
            IPortableDeviceValues pParameters,
            out string ppszCookie);

        void Unadvise(string pszCookie);

        void SendCommand(
            uint dwFlags, 
            ref IPortableDeviceValues pParameters,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppResults);
    }
}
