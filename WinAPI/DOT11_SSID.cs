// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential)] //, CharSet = CharSet.Ansi)]
    public struct DOT11_SSID
    {

        /// ULONG->unsigned int
        public int uSSIDLength; //uint

        /// UCHAR[]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ucSSID;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        //public byte[] ucSSID;
    }
}
