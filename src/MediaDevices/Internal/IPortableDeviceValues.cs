using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("6848F6F2-3155-4F86-B6F5-263EEEAB3143")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceValues : IComObject
    {
        void GetCount(
             ref uint pcelt);

        void GetAt(
            uint index,
            ref PropertyKey pKey,
            ref PropVariant pValue);

        void SetValue(
            ref PropertyKey key,
            ref PropVariant pValue);

        void GetValue(
            ref PropertyKey key,
            out PropVariant pValue);

        void SetStringValue(
            ref PropertyKey key,
            string Value);

        void GetStringValue(
            ref PropertyKey key, 
            out string pValue);

        void SetUnsignedIntegerValue(
            ref PropertyKey key,
            uint Value);

        void GetUnsignedIntegerValue(
            ref PropertyKey key, 
            out uint pValue);

        void SetSignedIntegerValue(
            ref PropertyKey key,
            int Value);

        void GetSignedIntegerValue(
            ref PropertyKey key, 
            out int pValue);

        void SetUnsignedLargeIntegerValue(
            ref PropertyKey key,
            ulong Value);

        void GetUnsignedLargeIntegerValue(
            ref PropertyKey key, 
            out ulong pValue);

        void SetSignedLargeIntegerValue(
            ref PropertyKey key,
            long Value);

        void GetSignedLargeIntegerValue(
            ref PropertyKey key, 
            out long pValue);

        void SetFloatValue(
            ref PropertyKey key,
            float Value);

        void GetFloatValue(
            ref PropertyKey key, 
            out float pValue);

        void SetErrorValue(
            ref PropertyKey key,
            int Value);

        void GetErrorValue(
            ref PropertyKey key, 
            out int pValue);

        void SetKeyValue(
            ref PropertyKey key,
            ref PropertyKey Value);

        void GetKeyValue(
            ref PropertyKey key, 
            out PropertyKey pValue);

        void SetBoolValue(
            ref PropertyKey key,
            int Value);

        void GetBoolValue(
            ref PropertyKey key, 
            out int pValue);

        void SetIUnknownValue(
            ref PropertyKey key,
            nint pValue);

        void GetIUnknownValue(
            ref PropertyKey key,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<object>))] out object ppValue);

        void SetGuidValue(
            ref PropertyKey key,
            ref Guid Value);

        void GetGuidValue(
            ref PropertyKey key, 
            out Guid pValue);

        void SetBufferValue(
            ref PropertyKey key,
            ref byte pValue,
            uint cbValue);

        void GetBufferValue(
            ref PropertyKey key, 
            out nint ppValue, 
            out uint pcbValue);

        void SetIPortableDeviceValuesValue(
            ref PropertyKey key,
            IPortableDeviceValues pValue);

        void GetIPortableDeviceValuesValue(
            ref PropertyKey key,
            out IPortableDeviceValues ppValue);

        void SetIPortableDevicePropVariantCollectionValue(
            ref PropertyKey key,
            IPortableDevicePropVariantCollection pValue);

        void GetIPortableDevicePropVariantCollectionValue(
            ref PropertyKey key,
            out IPortableDevicePropVariantCollection ppValue);

        void SetIPortableDeviceKeyCollectionValue(
            ref PropertyKey key,
            IPortableDeviceKeyCollection pValue);

        void GetIPortableDeviceKeyCollectionValue(
            ref PropertyKey key,
            out IPortableDeviceKeyCollection ppValue);

        void SetIPortableDeviceValuesCollectionValue(
            ref PropertyKey key,
            IPortableDeviceValuesCollection pValue);

        void GetIPortableDeviceValuesCollectionValue(
            ref PropertyKey key,
            out IPortableDeviceValuesCollection ppValue);

        void RemoveValue(
            ref PropertyKey key);

        void CopyValuesFromPropertyStore(
            IPropertyStore pStore);

        void CopyValuesToPropertyStore(
            IPropertyStore pStore);

        void Clear();
    }
}
