// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_RADIO_STATE
    {
        DOT11_RADIO_STATE dot11SoftwareRadioState;
        DOT11_RADIO_STATE dot11HardwareRadioState;
    }
}
