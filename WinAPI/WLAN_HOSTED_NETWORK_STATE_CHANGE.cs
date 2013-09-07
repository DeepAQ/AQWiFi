// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_STATE_CHANGE
    {
        public WLAN_HOSTED_NETWORK_STATE OldState;
        public WLAN_HOSTED_NETWORK_STATE NewState;
        public WLAN_HOSTED_NETWORK_REASON Reason; // NewState;
    }
}
