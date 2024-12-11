using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.Internal
{
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    [Guid("9B4ADD96-F6BF-4034-8708-ECA72BF10554")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPortableDeviceContent2 : IPortableDeviceContent
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void UpdateObjectWithPropertiesAndData(string pszObjectID, IPortableDeviceValues pProperties, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] out IStream ppData, out uint pdwOptimalWriteBufferSize);
    }

}
