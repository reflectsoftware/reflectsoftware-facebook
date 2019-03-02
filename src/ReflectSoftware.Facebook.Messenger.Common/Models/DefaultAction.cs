// ReflectSoftware.Facebook
// Copyright (c) 2019 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class DefaultAction
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("messenger_extensions", NullValueHandling = NullValueHandling.Ignore)]
        public string MessengerExtensions { get; set; }

        [JsonProperty("webview_height_ratio", NullValueHandling = NullValueHandling.Ignore)]
        public string WebviewHeightRatio { get; set; }

        [JsonProperty("fallback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RallbackUrl { get; set; }
    }
}
