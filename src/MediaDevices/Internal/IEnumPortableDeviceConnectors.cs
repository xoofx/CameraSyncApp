using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("BFDEF549-9247-454F-BD82-06FE80853FAA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IEnumPortableDeviceConnectors : IComObject
    {
        void Next(
            uint cRequested, 
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPortableDeviceConnector>))] out IPortableDeviceConnector pConnectors,
            //[In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ref IPortableDeviceConnector[] pPnPDeviceIDs,
            ref uint pcFetched);

        void Skip(
            uint cConnectors);

        void Reset();

        void Clone(
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IEnumPortableDeviceConnectors>))] out IEnumPortableDeviceConnectors ppEnum);
    }
}
