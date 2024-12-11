using System.Runtime.InteropServices.Marshalling;
using MediaDevices.Internal;

namespace MediaDevices.Internal
{
    [GeneratedComClass]
    internal partial class EventCallback : IPortableDeviceEventCallback
    {
        private MediaDevice device;

        public EventCallback(MediaDevice device)
        {
            this.device = device;
        }

        public void OnEvent(IPortableDeviceValues pEventParameters)
        {
            this.device.CallEvent(pEventParameters);
        }
    }
}
