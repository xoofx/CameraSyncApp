using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("24DBD89D-413E-43E0-BD5B-197F3C56C886")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceServiceCapabilities : IComObject
    {
        void GetSupportedMethods([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppMethods);

        void GetSupportedMethodsByFormat(in Guid Format, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppMethods);

        void GetMethodAttributes(in Guid Method, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void GetMethodParameterAttributes(in Guid Method, in PropertyKey Parameter, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void GetSupportedFormats([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppFormats);

        void GetFormatAttributes(in Guid Format, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void GetSupportedFormatProperties(in Guid Format, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceKeyCollection>))] out IPortableDeviceKeyCollection ppKeys);

        void GetFormatPropertyAttributes(in Guid Format, in PropertyKey Property, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void GetSupportedEvents([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppEvents);

        void GetEventAttributes(in Guid Event, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void GetEventParameterAttributes(in Guid Event, in PropertyKey Parameter, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppAttributes);

        void GetInheritedServices(uint dwInheritanceType, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDevicePropVariantCollection>))] out IPortableDevicePropVariantCollection ppServices);

        void GetFormatRenderingProfiles(in Guid Format, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValuesCollection>))] out IPortableDeviceValuesCollection ppRenderingProfiles);

        void GetSupportedCommands([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceKeyCollection>))] out IPortableDeviceKeyCollection ppCommands);

        void GetCommandOptions(in PropertyKey Command, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppOptions);

        void Cancel();
    }

}
