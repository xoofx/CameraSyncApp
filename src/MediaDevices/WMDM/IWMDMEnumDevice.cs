using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.WMDM
{
    [GeneratedComInterface]
    [Guid("1DCB3A01-33ED-11d3-8470-00C04F79DBC0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IWMDMEnumDevice : IComObject
    {
        void Next(
            uint celt,
            [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWMDMDevice>))] out IWMDMDevice ppDevice,
            out uint pceltFetched);
        
        void Skip(
            uint celt,
            out uint pceltFetched);
        
        void Reset();
        
        void Clone([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWMDMEnumDevice>))] out IWMDMEnumDevice ppEnumDevice);
    }
}
