// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    //http://msdn.microsoft.com/en-us/library/dd439500%28VS.85%29.aspx
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE
    {
        public WLAN_HOSTED_NETWORK_PEER_STATE OldState;
        public WLAN_HOSTED_NETWORK_PEER_STATE NewState;
        public WLAN_HOSTED_NETWORK_REASON Reason; //NewState;
    }
}
