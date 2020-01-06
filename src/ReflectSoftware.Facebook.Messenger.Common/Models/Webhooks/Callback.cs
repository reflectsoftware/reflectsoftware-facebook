// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    public class Callback
    {
        /// <summary>
        /// Value will be page
        /// </summary>
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public string Object { get; set; }

        /// <summary>
        /// Array containing event data
        /// </summary>
        [JsonProperty("entry", NullValueHandling = NullValueHandling.Ignore)]
        public List<Entry> Entry { get; set; }
    }
}
