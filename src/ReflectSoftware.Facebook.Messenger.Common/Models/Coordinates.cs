// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Coordinates
    {
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public string Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
        public string Longitude { get; set; }
    }
}
