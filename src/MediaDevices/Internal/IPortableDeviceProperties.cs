using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("7F6D695C-03DF-4439-A809-59266BEEE3A6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceProperties : IComObject
    {
        void GetSupportedProperties(
            string pszObjectID,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceKeyCollection>))] out IPortableDeviceKeyCollection ppKeys);

        void GetPropertyAttributes(
            string pszObjectID, 
            in PropertyKey key,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void GetValues(
            string pszObjectID,
            IPortableDeviceKeyCollection? pKeys,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppValues);

        void SetValues(
            string pszObjectID,
            IPortableDeviceValues pValues,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppResults);

        void Delete(
            string pszObjectID,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceKeyCollection>))] IPortableDeviceKeyCollection pKeys);

        void Cancel();
    }
}
