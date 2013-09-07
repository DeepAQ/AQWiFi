// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System.Runtime.InteropServices;

namespace AQWiFi
{
    //http://msdn.microsoft.com/en-us/library/ms706277%28VS.85%29.aspx
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NDIS_OBJECT_HEADER
    {
        string Type; //UCHAR
        string Revision; //UCHAR
        ushort Size;
    }
}
