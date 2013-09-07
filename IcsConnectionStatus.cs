﻿/*
* Virtual Router v1.0 - http://virtualrouter.codeplex.com
* Wifi Hot Spot for Windows 7 and 2008 R2
* Copyright (c) 2011 Chris Pietschmann (http://pietschsoft.com)
* Licensed under the Microsoft Public License (Ms-PL)
* http://virtualrouter.codeplex.com/license
*/

// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

namespace AQWiFi
{
    public enum IcsConnectionStatus : int
    {
        DISCONNECTED = 0,
        CONNECTING = 1,
        CONNECTED = 2,
        DISCONNECTING = 3,
        HARDWARE_NOT_PRESENT = 4,
        HARDWARE_DISABLED = 5,
        HARDWARE_MALFUNCTION = 6,
        MEDIA_DISCONNECTED = 7,
        AUTHENTICATING = 8,
        AUTHENTICATION_SUCCEEDED = 9,
        AUTHENTICATION_FAILED = 10,
        INVALID_ADDRESS = 11,
        CREDENTIALS_REQUIRED = 12,
    }
}
