// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class GenericTemplatePayload : TemplatePayload
    {
        public GenericTemplatePayload() : base("generic")
        {
        }

        public GenericTemplatePayload(List<GenericElement> elements) : this()
        {
            Elements = elements;
        }

        /// <summary>
        /// Gets or sets the image aspect ratio.
        /// </summary>
        /// <value>
        /// The image aspect ratio.
        /// </value>
        [JsonProperty("image_aspect_ratio", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageAspectRatio { get; set; }
        
        // <summary>
        /// Data for each bubble in message
        /// Bubbles per message (horizontal scroll): 10 elements
        /// </summary>
        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public List<GenericElement> Elements { get; set; }
    }
}
