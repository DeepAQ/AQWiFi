// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System;
using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_STATUS
    {
        public WLAN_HOSTED_NETWORK_STATE HostedNetworkState;
        public Guid IPDeviceID;
        public DOT11_MAC_ADDRESS wlanHostedNetworkBSSID;
        public DOT11_PHY_TYPE dot11PhyType;
        public uint ulChannelFrequency; // ULONG
        public uint dwNumberOfPeers; // DWORD
        //public WLAN_HOSTED_NETWORK_PEER_STATE PeerList[1];
        public IntPtr PeerList;
    }
}
