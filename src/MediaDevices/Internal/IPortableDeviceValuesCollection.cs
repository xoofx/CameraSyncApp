using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("6E3F2D79-4E07-48C4-8208-D8C2E5AF4A99")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceValuesCollection : IComObject
    {
        void GetCount(ref uint pcElems);

        void GetAt(
            uint dwIndex,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceValues>))] out IPortableDeviceValues ppValues);

        void Add(
            IPortableDeviceValues pValues);

        void Clear();

        void RemoveAt(
            uint dwIndex);
    }
}
