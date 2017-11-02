// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class ListButton : Button
    {
        public ListButton(string type) : base(type)
        {
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("messenger_extensions")]
        public bool MessengerExtensions { get; set; }

        [JsonProperty("webview_height_ratio")]
        public string WebviewHeightRatio { get; set; }

        [JsonProperty("fallback_url")]
        public string FallbackUrl { get; set; }
    }
}
