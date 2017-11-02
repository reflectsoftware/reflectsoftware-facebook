// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
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


        // <summary>
        /// Data for each bubble in message
        /// Bubbles per message (horizontal scroll): 10 elements
        /// </summary>
        [JsonProperty("elements")]
        public List<GenericElement> Elements { get; set; }
    }
}
