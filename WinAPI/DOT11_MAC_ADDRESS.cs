// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DOT11_MAC_ADDRESS
    {
        public byte one;
        public byte two;
        public byte three;
        public byte four;
        public byte five;
        public byte six;
    }
}
