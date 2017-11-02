// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using ReflectSoftware.Facebook.Messenger.Common.Interfaces;
using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Attachment<T> : IAttachment where T: IPayload
    {
        public Attachment(string type)
        {
            Type = type;
        }

        /// <summary>
        /// image, audio, video, file, location, template, fallback
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("payload")]
        public T Payload { get; set; }
    }
}
