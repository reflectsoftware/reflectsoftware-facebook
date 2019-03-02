// ReflectSoftware.Facebook
// Copyright (c) 2019 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Payload
    {
        [JsonProperty("is_reusable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsReusable { get; set; }
    }
}
