// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Enums
{
    public enum MessageType
    {        
        [JsonProperty("RESPONSE")]
        Response = 0,

        [JsonProperty("UPDATE")]
        Update,

        [JsonProperty("MESSAGE_TAG")]
        MessageTag
    }
}
