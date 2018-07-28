// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    /// <summary>
    /// This callback will occur when a message a page has sent has been delivered.
    /// You can subscribe to this callback by selecting the message_deliveries field when setting up your webhook.
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// Array containing message IDs of messages that were delivered. Field may not be present.
        /// </summary>
        [JsonProperty("mids", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Mids { get; set; }

        /// <summary>
        /// All messages that were sent before this timestamp were delivered
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
