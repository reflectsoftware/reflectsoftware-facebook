// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class MediaTemplatePayload : TemplatePayload
    {
        public MediaTemplatePayload() : base("media")
        {
        }

        public MediaTemplatePayload(List<MediaElement> elements) : this()
        {
            Elements = elements;
        }

        // <summary>
        /// Data for each bubble in message
        /// Bubbles per message (horizontal scroll): 10 elements
        /// </summary>
        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public List<MediaElement> Elements { get; set; }
    }
}

