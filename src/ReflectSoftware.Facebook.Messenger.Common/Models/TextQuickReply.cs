// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class TextQuickReply : QuickReply
    {
        public TextQuickReply() : base("text")
        {

        }

        public TextQuickReply(string title, string payload) : this()
        {
            Title = title;
            Payload = payload;
        }

        /// <summary>
        /// Caption of button (has a 20 character limit)
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Custom data that will be sent back to you via webhook (has a 1000 character limit)
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}
