// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Summary
    {
        /// <summary>
        /// Subtotal
        /// </summary>
        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Cost of shipping
        /// </summary>
        [JsonProperty("shipping_cost")]
        public decimal ShippingCost { get; set; }

        /// <summary>
        /// Total tax
        /// </summary>
        [JsonProperty("total_tax")]
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Total cost
        /// </summary>
        [JsonProperty("total_cost")]
        public decimal TotalCost { get; set; }
    }
}
