// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using ReflectSoftware.Facebook.Messenger.Common.Converters;
using ReflectSoftware.Facebook.Messenger.Common.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    public class MessageReceived
    {
        /// <summary>
        /// Message ID
        /// </summary>
        [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
        public string Mid { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        [JsonProperty("seq", NullValueHandling = NullValueHandling.Ignore)]
        public int Seq { get; set; }

        /// <summary>
        /// Text of message
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// Optional custom data provided by the sending app
        /// </summary>
        [JsonProperty("quick_reply", NullValueHandling = NullValueHandling.Ignore)]
        public QuickReplyReceived QuickReply { get; set; }

        /// <summary>
        /// Indicates the message sent from the page itself
        /// </summary>
        [JsonProperty("is_echo", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEcho { get; set; }

        /// <summary>
        /// ID of the app from which the message was sent
        /// </summary>
        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        /// <summary>
        /// Custom string passed to the Send API as the metadata field
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }

        /// <summary>
        /// attachment is used to send messages with images or Structured Messages
        /// </summary>
        [JsonProperty("attachments", ItemConverterType = typeof(AttachmentConverter))]
        public List<IAttachment> Attachments { get; set; }
    }
}
