using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    internal class Command
    {
        private readonly IPortableDeviceValues _values;
        private IPortableDeviceValues? _result;

        private Command(PropertyKey commandKey)
        {
            this._values = PortableDeviceValues.New();
            this._values.SetGuidValue(ref WPD.PROPERTY_COMMON_COMMAND_CATEGORY, ref commandKey.fmtid);
            this._values.SetUnsignedIntegerValue(ref WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);
        }

        public static Command Create(PropertyKey commandKey)
        {
            return new Command(commandKey);
        }

        public void Add(PropertyKey key, Guid value)
        {
            this._values.SetGuidValue(ref key, ref value);
        }

        public void Add(PropertyKey key, int value)
        {
            this._values.SetSignedIntegerValue(ref key, value);
        }

        public void Add(PropertyKey key, uint value)
        {
            this._values.SetUnsignedIntegerValue(ref key, value);
        }

        public void Add(PropertyKey key, IPortableDevicePropVariantCollection value)
        {
            this._values.SetIPortableDevicePropVariantCollectionValue(ref key, value);
        }
        
        public void Add(PropertyKey key, IEnumerable<int> values)
        {
            IPortableDevicePropVariantCollection col = PortableDevicePropVariantCollection.New();
            foreach (var value in values)
            {
                var var = PropVariantFacade.IntToPropVariant(value);
                col.Add(var.Value);
            }
            this._values.SetIPortableDevicePropVariantCollectionValue(ref key, col);
        }

        public void Add(PropertyKey key, string value)
        {
            this._values.SetStringValue(ref key, value);
        }

        //public void Add(PropertyKey key, byte[] buffer, int size)
        //{
        //    Marshal..
        //    this.values.SetBufferValue(key, ref buffer, (uint)size);
        //}

        public Guid GetGuid(PropertyKey key)
        {
            if (_result is null) throw new InvalidOperationException("Command not sent yet");

            Guid value;
            this._result.GetGuidValue(ref key, out value);
            return value;
        }

        public int GetInt(PropertyKey key)
        {
            if (_result is null) throw new InvalidOperationException("Command not sent yet");
            int value;
            this._result.GetSignedIntegerValue(ref key, out value);
            return value;
        }

        public string GetString(PropertyKey key)
        {
            if (_result is null) throw new InvalidOperationException("Command not sent yet");
            string value;
            this._result.GetStringValue(ref key, out value);
            return value;
        }
        
        public IEnumerable<PropVariantFacade> GetPropVariants(PropertyKey key) 
        {
            if (_result is null) throw new InvalidOperationException("Command not sent yet");
            this._result.GetIUnknownValue(ref key, out var obj);
            var col = (IPortableDevicePropVariantCollection)obj;
        
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                PropVariantFacade val = new PropVariantFacade();
                col.GetAt(i, ref val.Value);
                yield return val;
            }
        }

        public bool Has(PropertyKey key)
        {
            if (_result is null) throw new InvalidOperationException("Command not sent yet");
            uint count = 0;
            this._result.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                PropertyKey k = new PropertyKey();
                PropVariant v = new PropVariant();
                this._result.GetAt(i, ref k, ref v);
                if (key == k)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Send(IPortableDevice device)
        {
            device.SendCommand(0, this._values, out this._result);

            int error = 0;
            _result.GetErrorValue(ref WPD.PROPERTY_COMMON_HRESULT, out error);
            switch ((HResult)error)
            {
            case HResult.S_OK:
                return true;
            case HResult.E_NOT_IMPLEMENTED:
                Debug.WriteLine("Command not implemented!");
                return false;
            default:
                throw new Exception($"Error {error:X}");
            }
        }

        [Conditional("COMTRACE")]
        public void WriteResults()
        {
            if (_result is null) throw new InvalidOperationException("Command not sent yet");
            ComTrace.WriteObject(this._result);
        }
    }
}
