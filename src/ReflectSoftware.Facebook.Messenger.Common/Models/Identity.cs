// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Identity
    {
        public Identity(string id = null)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
