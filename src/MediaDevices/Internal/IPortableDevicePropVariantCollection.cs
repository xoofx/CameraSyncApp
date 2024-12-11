using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("89B2E422-4F1B-4316-BCEF-A44AFEA83EB3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDevicePropVariantCollection : IComObject
    {
        void GetCount(
            ref uint pcElems);

        void GetAt(
            uint dwIndex, 
            ref PropVariant pValue);

        void Add(
            in PropVariant pValue);

        void GetType(
            out ushort pvt);

        void ChangeType(
            ushort vt);
         
        void Clear();

        void RemoveAt(
            uint dwIndex);
    }
}
