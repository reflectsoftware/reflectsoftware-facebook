// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Client
{
    public class MessageResult : Result
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }
    }
}
