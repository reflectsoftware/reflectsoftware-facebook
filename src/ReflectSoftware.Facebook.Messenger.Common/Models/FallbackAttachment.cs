// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// A fallback attachment is any attachment not currently recognized or supported by the Message Echo feature.
    /// </summary>
    public class FallbackAttachment : Attachment<MediaPayload>
    {
        public FallbackAttachment() : base("fallback")
        {
        }

        /// <summary>
        /// Title of attachment (optional)
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// URL of attachment (optional)
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
