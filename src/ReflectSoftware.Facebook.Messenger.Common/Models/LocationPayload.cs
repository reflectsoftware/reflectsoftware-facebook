// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class LocationPayload : Payload
    {
        public LocationPayload()
        {

        }

        public LocationPayload(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        [JsonProperty("coordinates", NullValueHandling = NullValueHandling.Ignore)]
        public Coordinates Coordinates { get; set; }
    }
}
