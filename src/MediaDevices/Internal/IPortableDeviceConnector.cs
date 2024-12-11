using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceConnector : IComObject
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Connect(IConnectionRequestCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Disconnect(IConnectionRequestCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Cancel(IConnectionRequestCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetProperty(ref PropertyKey pPropertyKey, out uint pPropertyType, out nint ppData, out uint pcbData);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetProperty(ref PropertyKey pPropertyKey, uint PropertyType, ref byte pData, uint cbData);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetPnPID(out string ppwszPnPID);
    }
}
