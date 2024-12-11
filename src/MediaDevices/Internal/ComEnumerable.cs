using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace MediaDevices.Internal
{
    internal static class ComEnumerable
    {
        public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePair(this IPortableDeviceValues values)
        {
            uint num = 0;
            values.GetCount(ref num);
            for (uint i = 0; i < num; i++)
            {
                PropertyKey key = new PropertyKey();
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    values.GetAt(i, ref key, ref val.Value);


                    string fieldName = string.Empty;
                    FieldInfo? propField = ComTrace.FindPropertyKeyField(key);
                    if (propField != null)
                    {
                        fieldName = propField.Name;
                    }
                    else
                    {
                        FieldInfo? guidField = ComTrace.FindGuidField(key.fmtid);
                        if (guidField != null)
                        {
                            fieldName = $"{guidField.Name}, {key.pid}";
                        }
                        else
                        {
                            fieldName = $"{key.fmtid}, {key.pid}";
                        }
                    }
                    string fieldValue = string.Empty;
                    switch (val.VariantType)
                    {
                        case PropVariantType.VT_CLSID:
                            fieldValue = ComTrace.FindGuidField(val.ToGuid())?.Name ?? val.ToString();
                            break;
                        default:
                            fieldValue = val.ToDebugString() ?? string.Empty;
                            break;
                    }

                    yield return new KeyValuePair<string, string>(fieldName, fieldValue);
                }
            }

        }

        
        public static Guid Guid<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] TEnum>(this TEnum e) where TEnum : System.Enum
        {
            FieldInfo fi = typeof(TEnum).GetField(e.ToString()!)!;

            // changed for .net framework 4.0
            // EnumGuidAttribute attribute = fi.GetCustomAttribute<EnumGuidAttribute>();
            EnumGuidAttribute? attribute = Attribute.GetCustomAttribute(fi, typeof(EnumGuidAttribute)) as EnumGuidAttribute;
            return attribute!.Guid;
        }

        public static IEnumerable<PropertyKey> ToEnum(this IPortableDeviceKeyCollection col) 
        {
            uint count = 0;
            col.GetCount(out count);
            for (uint i = 0; i < count; i++)
            {
                col.GetAt(i, out var key);
                yield return key;
            }
        }

        public static IEnumerable<TEnum> ToEnum<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] TEnum>(this IPortableDeviceKeyCollection col) where TEnum : struct, Enum
        {
            uint count = 0;
            col.GetCount(out count);
            for (uint i = 0; i < count; i++)
            {
                col.GetAt(i, out var key);
                yield return GetEnumFromAttrKey<TEnum>(key);
            }
        }

        public static IEnumerable<TEnum> ToEnum<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] TEnum>(this IPortableDevicePropVariantCollection col) where TEnum : struct, Enum
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    col.GetAt(i, ref val.Value);
                    yield return GetEnumFromAttrGuid<TEnum>(val.ToGuid());
                }
            }
        }
        
        
        public static T GetEnum<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>(this Guid guid) where T : struct, System.Enum
        {
            var names = Enum.GetNames<T>();
            var values = Enum.GetValues<T>();

            for (int i = 0; i < names.Length; i++)
            {
                FieldInfo fi = typeof(T).GetField(names[i])!;
                // changed for .net framework 4.0
                // EnumGuidAttribute attribute = fi.GetCustomAttribute<EnumGuidAttribute>();

                EnumGuidAttribute? attribute = Attribute.GetCustomAttribute(fi, typeof(EnumGuidAttribute)) as EnumGuidAttribute;
                if (attribute!.Guid == guid)
                {
                    return (T)values.GetValue(i)!;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(guid), guid, "Unknown Guid");
        }


        public static T GetEnumFromAttrKey<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>(this PropertyKey key) where T : struct, Enum
        {
            var names = Enum.GetNames<T>();
            var values = Enum.GetValues<T>();

            for (int i = 0; i < names.Length; i++)
            {
                FieldInfo fi = typeof(T).GetField(names[i])!;
                // changed for .net framework 4.0
                // KeyAttribute attr = fi.GetCustomAttribute<KeyAttribute>();
                KeyAttribute? attr = Attribute.GetCustomAttribute(fi, typeof(KeyAttribute)) as KeyAttribute;
                if (attr!.PropertyKey == key)
                {
                    return (T)values.GetValue(i)!;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(key), key, "Unknown Key");
        }

        public static T GetEnumFromAttrGuid<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>(this Guid guid) where T : struct, Enum
        {
            var names = Enum.GetNames<T>();
            var values = Enum.GetValues<T>();

            for (int i = 0; i < names.Length; i++)
            {
                FieldInfo fi = typeof(T).GetField(names[i])!;
                // changed for .net framework 4.0
                // EnumGuidAttribute attr = fi.GetCustomAttribute<EnumGuidAttribute>();
                EnumGuidAttribute? attr = Attribute.GetCustomAttribute(fi, typeof(EnumGuidAttribute)) as EnumGuidAttribute;
                if (attr!.Guid == guid)
                {
                    return (T)values.GetValue(i)!;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(guid), guid, "Unknown Guid");
        }

        public static IEnumerable<Guid> ToGuid(this IPortableDevicePropVariantCollection col) 
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    col.GetAt(i, ref val.Value);
                    yield return val.ToGuid();
                }
            }
        }

        public static IEnumerable<string> ToStrings(this IPortableDevicePropVariantCollection col)
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    col.GetAt(i, ref val.Value);
                    yield return val.ToString();
                }
            }
        }
    }
}
