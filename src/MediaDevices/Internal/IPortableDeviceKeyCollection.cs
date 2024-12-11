using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("DADA2357-E0AD-492E-98DB-DD61C53BA353")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceKeyCollection : IComObject
    {
        void GetCount(
            out uint pcElems);

        void GetAt(
            uint dwIndex,
            out PropertyKey pKey);

        void Add(
            in PropertyKey key);

        void Clear();

        void RemoveAt(
            uint dwIndex);
    }
}
