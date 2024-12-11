using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("FD8878AC-D841-4D17-891C-E6829CDB6934")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceResources : IComObject
    {
        void GetSupportedResources(
            string pszObjectID,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceKeyCollection>))] out IPortableDeviceKeyCollection ppKeys);

        void GetResourceAttributes(
            string pszObjectID, 
            in PropertyKey key,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppResourceAttributes);

        void GetStream(
            string pszObjectID, 
            in PropertyKey key, 
            uint dwMode, 
            ref uint pdwOptimalBufferSize,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] out IStream ppStream);

        void Delete(
            string pszObjectID,
            IPortableDeviceKeyCollection pKeys);

        void Cancel();

        void CreateResource(
            IPortableDeviceValues pResourceAttributes,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] out IStream ppData,
            ref uint pdwOptimalWriteBufferSize,
            ref string ppszCookie);
    }
}
