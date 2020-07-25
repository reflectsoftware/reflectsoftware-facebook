// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class TextQuickReply : QuickReply
    {
        public TextQuickReply() : base("text")
        {

        }

        public TextQuickReply(string title, string payload, string imageUrl = null) : this()
        {
            Title = title;
            Payload = payload;
            ImageUrl = imageUrl;
        }

        /// <summary>
        /// Caption of button (has a 20 character limit)
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Custom data that will be sent back to you via webhook (has a 1000 character limit)
        /// </summary>
        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public string Payload { get; set; }
    }
}
