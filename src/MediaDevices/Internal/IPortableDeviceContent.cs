using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("6A96ED84-7C73-4480-9938-BF5AF477D426")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceContent : IComObject
    {
        void EnumObjects(
            uint dwFlags,
            string pszParentObjectID,
            IPortableDeviceValues? pFilter,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IEnumPortableDeviceObjectIDs>))] out IEnumPortableDeviceObjectIDs? ppenum);

        void Properties(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceProperties>))] out IPortableDeviceProperties ppProperties);

        void Transfer(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceResources>))] out IPortableDeviceResources ppResources);

        void CreateObjectWithPropertiesOnly(
            IPortableDeviceValues pValues,
            ref string? ppszObjectID);

        void CreateObjectWithPropertiesAndData(
            IPortableDeviceValues pValues,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] out IStream ppData, 
            ref uint pdwOptimalWriteBufferSize, 
            ref string? ppszCookie);

        void Delete(
            uint dwOptions,
            IPortableDevicePropVariantCollection pObjectIDs,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] ref IPortableDevicePropVariantCollection ppResults);

        void GetObjectIDsFromPersistentUniqueIDs(
            IPortableDevicePropVariantCollection pPersistentUniqueIDs,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppObjectIDs);

        void Cancel();

        void Move(
            IPortableDevicePropVariantCollection pObjectIDs,
            string pszDestinationFolderObjectID,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] ref IPortableDevicePropVariantCollection ppResults);

        void Copy(
            IPortableDevicePropVariantCollection pObjectIDs,
            string pszDestinationFolderObjectID,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] ref IPortableDevicePropVariantCollection ppResults);
    }
}
