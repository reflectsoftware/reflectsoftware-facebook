// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class PostbackButton : Button
    {
        public PostbackButton() : base("postback")
        {
        }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public string Payload { get; set; }
    }
}
