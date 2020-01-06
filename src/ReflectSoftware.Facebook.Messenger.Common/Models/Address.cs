// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Address
    {
        /// <summary>
        /// Street Address, line 1
        /// </summary>
        [JsonProperty("street_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Street1 { get; set; }

        /// <summary>
        /// Street Address, line 2
        /// </summary>
        [JsonProperty("street_2", NullValueHandling = NullValueHandling.Ignore)]
        public string Street2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// US Postal Code
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        /// <summary>
        /// State abbreviation or Region/Province (international)
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        /// <summary>
        /// Two-letter country abbreviation
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
    }
}
