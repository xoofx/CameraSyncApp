using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.Internal
{

    [GeneratedComInterface]
    [Guid("E20333C9-FD34-412D-A381-CC6F2D820DF7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceServiceMethods : IComObject
    {
        void Invoke(in Guid Method, IPortableDeviceValues pParameters, ref IPortableDeviceValues ppResults);

        void InvokeAsync(in Guid Method, IPortableDeviceValues pParameters, IPortableDeviceServiceMethodCallback pCallback);

        void Cancel(IPortableDeviceServiceMethodCallback pCallback);
    }
}
