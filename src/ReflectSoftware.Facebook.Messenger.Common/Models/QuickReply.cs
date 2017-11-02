// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public abstract class QuickReply
    {
        public QuickReply(string contentType)
        {
            ContentType = contentType;
        }

        /// <summary>
        /// Value must be text or location
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; private set; }       

        /// <summary>
        /// Image for image_url should be at least 24x24 and will be cropped and resized
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}
