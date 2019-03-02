﻿// ReflectSoftware.Facebook
// Copyright (c) 2019 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class LocationAttachment : Attachment<LocationPayload>
    {
        public LocationAttachment() : base("location")
        {
        }

        public LocationAttachment(Coordinates coordinates) : this()
        {
            Payload = new LocationPayload(coordinates);
        }

        /// <summary>
        /// Title of attachment (optional)
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// URL of attachment (optional)
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }
}
