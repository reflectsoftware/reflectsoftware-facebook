// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using ReflectSoftware.Facebook.Messenger.Common.Interfaces;
using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class LocationPayload : IPayload
    {
        public LocationPayload()
        {

        }

        public LocationPayload(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
    }
}
