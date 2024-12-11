using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("2C8C6DBF-E3DC-4061-BECC-8542E810D126")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceCapabilities : IComObject
    {
        void GetSupportedCommands(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceKeyCollection>))] out IPortableDeviceKeyCollection ppCommands);

        void GetCommandOptions(
            ref PropertyKey Command,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppOptions);

        void GetFunctionalCategories(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppCategories);

        void GetFunctionalObjects(
            ref Guid Category,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppObjectIDs);

        void GetSupportedContentTypes(
            ref Guid Category,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppContentTypes);

        void GetSupportedFormats(
            ref Guid ContentType,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppFormats);

        void GetSupportedFormatProperties(
            ref Guid Format,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceKeyCollection>))] out IPortableDeviceKeyCollection ppKeys);

        void GetFixedPropertyAttributes(
            ref Guid Format,
            ref PropertyKey key,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void Cancel();

        void GetSupportedEvents(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppEvents);

        void GetEventOptions(
            ref Guid Event,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppOptions);
    }
}
