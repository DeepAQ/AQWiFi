// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

namespace AQWiFi
{
 /// <summary>
 /// Indicates the type of an MSM (<see cref="WlanNotificationSource.MSM"/>) notification.
 /// </summary>
 /// <remarks>
 /// The enumeration identifiers correspond to the native <c>wlan_notification_msm_</c> identifiers.
 /// </remarks>
 public enum WLAN_NOTIFICATION_CODE_MSM
 {
 Associating = 1,
 Associated,
 Authenticating,
 Connected,
 RoamingStart,
 RoamingEnd,
 RadioStateChange,
 SignalQualityChange,
 Disassociating,
 Disconnected,
 PeerJoin,
 PeerLeave,
 AdapterRemoval,
 AdapterOperationModeChange
 } 
}
