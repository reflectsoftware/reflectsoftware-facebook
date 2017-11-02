// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using ReflectSoftware.Facebook.Messenger.Common.Interfaces;
using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class MediaPayload : IPayload
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
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
