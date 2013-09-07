// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System;
using System.Runtime.InteropServices;

namespace AQWiFi
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_INTERFACE_INFO
    {
        /// GUID->_GUID
        public Guid InterfaceGuid;

        /// WCHAR[256]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strInterfaceDescription;

        /// WLAN_INTERFACE_STATE->_WLAN_INTERFACE_STATE
        public WLAN_INTERFACE_STATE isState;
    }
}
