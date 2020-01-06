﻿// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class MediaPayload : Payload
    {
        public MediaPayload()
        {

        }

        public MediaPayload(string url)
        {
            Url = url;
        }

        /// <summary>
        /// URL of media
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("sticker_id", NullValueHandling = NullValueHandling.Ignore)]
        public string StickerId { get; set; }
    }
}
