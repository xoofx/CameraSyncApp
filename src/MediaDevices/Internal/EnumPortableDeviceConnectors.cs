using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.Internal
{
    internal static class EnumPortableDeviceConnectors
    {
        public static readonly Guid ClsId = new("A1570149-E645-4F43-8B0D-409B061DB2FC");

        public static IEnumPortableDeviceConnectors New() => ComHelper.ActivateClass<IEnumPortableDeviceConnectors>(ClsId);
    }
}
