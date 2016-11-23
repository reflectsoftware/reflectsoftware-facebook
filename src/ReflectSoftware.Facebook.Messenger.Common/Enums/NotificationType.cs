// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Enums
{
    public enum NotificationType
    {
        /// <summary>
        /// REGULAR will emit a sound/vibration and a phone notification
        /// </summary>
        [JsonProperty("REGULAR")]
        Regular = 0,

        /// <summary>
        /// SILENT_PUSH will just emit a phone notification
        /// </summary>
        [JsonProperty("SILENT_PUSH")]
        SilentPush,

        /// <summary>
        /// NO_PUSH will not emit either
        /// </summary>
        [JsonProperty("NO_PUSH")]
        NoPush
    }
}
