// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System;
using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential)] //, CharSet =  CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS
    {
        public DOT11_SSID hostedNetworkSSID;
        public UInt32 dwMaxNumberOfPeers; // DWORD
    }
}
