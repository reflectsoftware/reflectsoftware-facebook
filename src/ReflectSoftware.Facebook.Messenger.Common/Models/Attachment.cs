// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Attachment
    {
        /// <summary>
        /// image, audio, video, file, location, template, fallback
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; private set; }

        public Attachment(string type)
        {
            Type = type;
        }        
    }

    //public class Attachment<T> : IAttachment where T: IPayload
    public class Attachment<T> : Attachment where T : Payload
    {
        public Attachment(string type) : base(type)
        {
        }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public T Payload { get; set; }
    }
}
