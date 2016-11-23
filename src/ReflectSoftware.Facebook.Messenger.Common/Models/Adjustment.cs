// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Adjustment
    {
        /// <summary>
        /// Name of adjustment
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Adjusted amount
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
