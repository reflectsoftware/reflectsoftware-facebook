// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Summary
    {
        /// <summary>
        /// Subtotal
        /// </summary>
        [JsonProperty("subtotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Cost of shipping
        /// </summary>
        [JsonProperty("shipping_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ShippingCost { get; set; }

        /// <summary>
        /// Total tax
        /// </summary>
        [JsonProperty("total_tax", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Total cost
        /// </summary>
        [JsonProperty("total_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TotalCost { get; set; }
    }
}
