using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal
{
    [GeneratedComInterface]
    [Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IPropertyStore : IComObject
    {
        void GetCount(
            out uint cProps);

        void GetAt(
            uint iProp, 
            out PropertyKey pKey);

        void GetValue(
            in PropertyKey key, 
            out PropVariant pv);

        void SetValue(
            in PropertyKey key,
            in PropVariant propvar);

        void Commit();
    }
}
