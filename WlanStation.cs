/*
* Virtual Router v1.0 - http://virtualrouter.codeplex.com
* Wifi Hot Spot for Windows 7 and 2008 R2
* Copyright (c) 2011 Chris Pietschmann (http://pietschsoft.com)
* Licensed under the Microsoft Public License (Ms-PL)
* http://virtualrouter.codeplex.com/license
*/

// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

namespace AQWiFi
{
    public class WlanStation
    {
        public WlanStation(WLAN_HOSTED_NETWORK_PEER_STATE state)
        {
            this.State = state;
        }

        public WLAN_HOSTED_NETWORK_PEER_STATE State { get; set; }

        public string MacAddress
        {
            get
            {
                return this.State.PeerMacAddress.ConvertToString();
            }
        }
    }
}
