// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DOT11_BSSID_LIST
    {
        NDIS_OBJECT_HEADER header;
        uint uNumOfEntries; // ULONG
        uint uTotalNumOfEntries; // ULONG
        DOT11_MAC_ADDRESS[] BSSIDs;
    }
}
