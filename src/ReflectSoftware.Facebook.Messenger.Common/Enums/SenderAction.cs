// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Enums
{
    public enum SenderAction
    {
        /// <summary>
        /// Mark last message as read
        /// </summary>
        [JsonProperty("mark_seen")]
        MarkSeen,

        /// <summary>
        /// Turn typing indicators on
        /// </summary>
        [JsonProperty("typing_on")]
        TypingOn,

        /// <summary>
        /// Turn typing indicators off
        /// </summary>
        [JsonProperty("typing_off")]
        TypingOff
    }
}
