// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using ReflectSoftware.Facebook.Messenger.Common.Converters;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    public class MessageReceived
    {
        [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
        public string Mid { get; set; }

        [JsonProperty("seq", NullValueHandling = NullValueHandling.Ignore)]
        public int Seq { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("sticker_id", NullValueHandling = NullValueHandling.Ignore)]
        public string StickerId { get; set; }

        [JsonProperty("quick_reply", NullValueHandling = NullValueHandling.Ignore)]
        public QuickReplyReceived QuickReply { get; set; }

        [JsonProperty("is_echo", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEcho { get; set; }

        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }

        [JsonProperty("attachments", ItemConverterType = typeof(AttachmentConverter))]
        public List<Attachment> Attachments { get; set; }
    }
}
