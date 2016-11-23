// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    public class Entry
    {
        /// <summary>
        /// Page ID of page
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Time of update (epoch time in milliseconds)
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// Array containing objects related to messaging
        /// </summary>
        [JsonProperty("messaging")]
        public List<Messaging> Messaging { get; set; }
    }
}
