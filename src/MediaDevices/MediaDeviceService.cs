using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaDevices
{

    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17763.0\um\propkey.h

    /// <summary>
    /// MediaDevice service class
    /// </summary>
    public class MediaDeviceService : IDisposable
    {
        private readonly MediaDevice _device;
        private IPortableDeviceService? _service = PortableDeviceService.New();
        //protected IPortableDeviceValues values;
        private readonly IPortableDeviceServiceCapabilities _capabilities;
        
        internal readonly IPortableDeviceContent2 Content;

        internal MediaDeviceService(MediaDevice device, string serviceId)
        {
            this._device = device;
            this.ServiceId = serviceId;

            //Match match = Regex.Match(serviceId, @".*#(?<service>\{.*\})\\(?<name>\{.*\})");
            //if (match.Success)
            //{
            //    string service = match.Groups["service"].Value;
            //    Guid serviceGuid = new Guid(service);
            //    this.Service = serviceGuid.GetEnum<Services>();
            //    string serviceName = match.Groups["name"].Value;
            //    this.ServiceName = $"{this.Service} : {service} : {serviceName}";
            //}
            //else
            //{
            //    this.ServiceName = "Unknown";
            //}
            //this.ServiceName = serviceId.Substring(serviceId.LastIndexOf(@"\") + 1);

            IPortableDeviceValues values = PortableDeviceValues.New();
            this._service.Open(this.ServiceId, values);

            this._service.GetServiceObjectID(out string serviceObjectID);
            this.ServiceObjectID = serviceObjectID;

            this._service.GetPnPServiceID(out string pnPServiceID);
            this.PnPServiceID = pnPServiceID;

            this._service.Capabilities(out _capabilities);

            this._service.Content(out Content);

            Content.Properties(out IPortableDeviceProperties properties);

            properties.GetSupportedProperties(this.ServiceObjectID, out IPortableDeviceKeyCollection keyCol);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            ComTrace.WriteObject(deviceValues);

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0090 // Use 'new(...)'

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.OBJECT_NAME, out value.Value);
                this.Name = value;
            }

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.FUNCTIONAL_OBJECT_CATEGORY, out value.Value);
                
                Guid serviceGuid = new Guid((string)value);
                this.Service = serviceGuid.GetEnum<MediaDeviceServices>();
                this.ServiceName = this.Service != MediaDeviceServices.Unknown ? this.Service.ToString() : serviceGuid.ToString();
            }

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.SERVICE_VERSION, out value.Value);
                this.ServiceVersion = value;
            }

#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE0079 // Remove unnecessary suppression

            Update();

            //var x = GetContent().ToArray();

            
        }

        /// <summary>
        /// Dispose service
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose service
        /// </summary>
        /// <param name="disposing">Disposing flag</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._service != null)
                {
                    this._service.Close();
                    this._service = null;
                }
            }
        }

        /// <summary>
        /// ID of the service
        /// </summary>
        public string ServiceId { get; private set; }

        /// <summary>
        /// Get services
        /// </summary>
        public MediaDeviceServices Service { get; private set; }

        /// <summary>
        /// Name of the service
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Servicename
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// Version of the service
        /// </summary>
        public string ServiceVersion { get; private set; }

        /// <summary>
        /// OhjectID of the service
        /// </summary>
        public string ServiceObjectID { get; private set; }

        /// <summary>
        /// PnP service ID
        /// </summary>
        public string PnPServiceID { get; private set; }

        /// <summary>
        /// Info of the service
        /// </summary>
        /// <returns>String with the info</returns>
        public override string ToString()
        {
            return $"{this.Name} : {this.ServiceName} : {this.ServiceVersion}";
        }

        /// <summary>
        /// Get content of the service
        /// </summary>
        /// <returns>List of content services</returns>
        public IEnumerable<MediaDeviceServiceContent> GetContent()
        {
            return GetContent("DEVICE");
        }

        internal IEnumerable<MediaDeviceServiceContent> GetContent(string objectID)
        {
            this.Content.EnumObjects(0, objectID, null, out IEnumPortableDeviceObjectIDs enumerator);

            uint num = 0;
            string[] objectIdArray = new string[20];
            enumerator.Next(20, objectIdArray, ref num);

            return objectIdArray.Take((int)num).Select(o => new MediaDeviceServiceContent(this, o));
        }

        internal IEnumerable<KeyValuePair<string, string>> GetAllProperties(string objectID)
        {
            this.Content.Properties(out IPortableDeviceProperties properties);

            properties.GetSupportedProperties(objectID, out IPortableDeviceKeyCollection keyCol);

            properties.GetValues(objectID, keyCol, out IPortableDeviceValues deviceValues);

            return deviceValues.ToKeyValuePair();
        }
               
        internal IPortableDeviceValues GetProperties(IPortableDeviceKeyCollection keyCol)
        {
            this.Content.Properties(out IPortableDeviceProperties properties);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            return deviceValues;
        }
        
        /// <summary>
        /// Update service
        /// </summary>
        protected virtual void Update()
        {
            this.Content.Properties(out IPortableDeviceProperties properties);

            properties.GetSupportedProperties(this.ServiceObjectID, out IPortableDeviceKeyCollection keyCol);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            ComTrace.WriteObject(deviceValues);
        }

        /// <summary>
        /// Get all properties
        /// </summary>
        /// <returns>List of properties</returns>
        public IEnumerable<KeyValuePair<string,string>> GetAllProperties()
        {
            return GetAllProperties(this.ServiceObjectID);
        }

        /// <summary>
        /// Get supported methods
        /// </summary>
        /// <returns>List of supported methods</returns>
        public IEnumerable<Methods> GetSupportedMethods()
        {
            _capabilities.GetSupportedMethods(out IPortableDevicePropVariantCollection methods);
            ComTrace.WriteObject(methods);
            return methods.ToEnum<Methods>();
        }

        /// <summary>
        /// Get supported commands
        /// </summary>
        /// <returns>List of supported commands</returns>
        public IEnumerable<Commands> GetSupportedCommands()
        {
            _capabilities.GetSupportedCommands(out IPortableDeviceKeyCollection commands);
            ComTrace.WriteObject(commands);
            return commands.ToEnum<Commands>();
        }

        /// <summary>
        /// Get supported events
        /// </summary>
        /// <returns>list of supported events</returns>
        public IEnumerable<Events> GetSupportedEvents()
        {
            _capabilities.GetSupportedEvents(out IPortableDevicePropVariantCollection events);
            ComTrace.WriteObject(events);
            return events.ToEnum<Events>();
        }

        /// <summary>
        /// Get supported formats
        /// </summary>
        /// <returns>List of supported formats</returns>
        public IEnumerable<Formats> GetSupportedFormats()
        {
            _capabilities.GetSupportedFormats(out IPortableDevicePropVariantCollection formats);
            ComTrace.WriteObject(formats);
            return formats.ToEnum<Formats>();
        }
       
        /// <summary>
        /// Call a service method
        /// </summary>
        /// <param name="method">Method GUID</param>
        /// <param name="parameters">Method parameters</param>
#pragma warning disable IDE0060 // Remove unused parameter
        public void CallMethod(Guid method, object[] parameters)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            this._service!.Methods(out IPortableDeviceServiceMethods methods);

            IPortableDeviceValues values = PortableDeviceValues.New();
            //values.SetStringValue();
            IPortableDeviceValues results = PortableDeviceValues.New();
            methods.Invoke(method, values, ref results);
        }

        internal void SendCommand(PropertyKey commandKey)
        {
            IPortableDeviceValues values = PortableDeviceValues.New();
            values.SetGuidValue(ref WPD.PROPERTY_COMMON_COMMAND_CATEGORY, ref commandKey.fmtid);
            values.SetUnsignedIntegerValue(ref WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            this._service!.SendCommand(0, ref values, out IPortableDeviceValues results);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        }
    }
}
