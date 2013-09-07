// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_HOSTED_NETWORK_SECURITY_SETTINGS
    {
        DOT11_AUTH_ALGORITHM dot11AuthAlgo;
        DOT11_CIPHER_ALGORITHM dot11CipherAlgo;
    }
}
