﻿// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// Use the Receipt Template with the Send API to send a order confirmation, with the transaction summary and description for each item.
    /// Notes
    /// order_number must be unique per call.
    /// payment_method is required but is a String. You may insert an arbitrary string here but we recommend providing enough information for the person to decipher which payment method and account they used (e.g., the name of the payment method and partial account number)
    /// address is optional.If you do not ship an item, you may omit these fields.
    /// adjustments allow a way to insert adjusted pricing (e.g., sales). Adjustments are optional.
    /// </summary>
    public class ReceiptTemplatePayload : TemplatePayload
    {
        public ReceiptTemplatePayload()  : base("receipt")
        {
        }

        /// <summary>
        /// Recipient's Name
        /// </summary>
        [JsonProperty("recipient_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientName { get; set; }

        /// <summary>
        /// Merchant's name. If present this is shown as logo text.
        /// </summary>
        [JsonProperty("merchant_name", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantName { get; set; }

        /// <summary>
        /// Order number. (must be unique for each user)
        /// </summary>
        [JsonProperty("order_number", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Currency for order
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>
        /// Payment method details. This can be a custom string. Ex: 'Visa 1234'
        /// payment_method is required but is a String. You may insert an arbitrary string here but we recommend providing enough information for the person to decipher which payment method and account they used (e.g., the name of the payment method and partial account number) 
        /// </summary>
        [JsonProperty("payment_method", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Timestamp of the order, in seconds.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long Timestamp { get; set; }

        /// <summary>
        /// URL of order
        /// </summary>
        [JsonProperty("order_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderUrl { get; set; }

        /// <summary>
        /// Items in order (has a maximum of 100)
        /// </summary>
        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public List<ReceiptElement> Elements { get; set; }

        /// <summary>
        /// Shipping address
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Address Address { get; set; }

        /// <summary>
        /// Payment summary
        /// </summary>
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public Summary Summary { get; set; }

        /// <summary>
        /// Payment adjustments
        /// </summary>
        [JsonProperty("adjustments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Adjustment> Adjustments { get; set; }
    }
}
