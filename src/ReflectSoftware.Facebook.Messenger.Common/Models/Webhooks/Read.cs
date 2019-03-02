// ReflectSoftware.Facebook
// Copyright (c) 2019 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    /// <summary>
    /// This callback will occur when a message a page has sent has been read by the user.
    /// You can subscribe to this callback by selecting the message_reads field when setting up your webhook.
    /// </summary>
    public class Read
    {
        /// <summary>
        /// All messages that were sent before this timestamp were read
        /// </summary>
        [JsonProperty("watermark", NullValueHandling = NullValueHandling.Ignore)]
        public string Watermark { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        [JsonProperty("seq", NullValueHandling = NullValueHandling.Ignore)]
        public int Seq { get; set; }
    }
}
