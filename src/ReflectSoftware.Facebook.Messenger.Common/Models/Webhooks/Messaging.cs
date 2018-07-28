// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{    
    public class Messaging
    {
        /// <summary>
        /// Sender user ID
        /// </summary>
        [JsonProperty("sender", NullValueHandling = NullValueHandling.Ignore)]
        public Identity Sender { get; set; }

        /// <summary>
        /// Recipient user ID
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Identity Recipient { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long Timestamp { get; set; }

        #region Options
        /// <summary>
        /// This callback will occur when a message has been sent to your page. You may receive text messages or messages with attachments (image, audio, video, file or location). Callbacks contain a seq number which can be used to know the sequence of a message in a conversation. Messages are always sent in order.
        /// You can subscribe to this callback by selecting the message field when setting up your webhook.
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public MessageReceived Message { get; set; }

        /// <summary>
        /// Postbacks occur when a Postback button, Get Started button, Persistent menu or Structured Message is tapped. The payload field in the callback is defined on the button.
        /// You can subscribe to this callback by selecting the messaging_postbacks field when setting up your webhook.
        /// </summary>
        [JsonProperty("postback", NullValueHandling = NullValueHandling.Ignore)]
        public Postback Postback { get; set; }

        /// <summary>
        /// This callback will occur when the Send-to-Messenger plug-in has been tapped. The optin.ref parameter is set by the data-ref field on the "Send to Messenger" plugin. This field can be used by the developer to associate a click event on the plugin with a callback.
        /// You can subscribe to this callback by selecting the messaging_optins field when setting up your webhook.
        /// </summary>
        [JsonProperty("optin", NullValueHandling = NullValueHandling.Ignore)]
        public Optin Optin { get; set; }

        /// <summary>
        /// This callback will occur when a message a page has sent has been delivered.
        /// You can subscribe to this callback by selecting the message_deliveries field when setting up your webhook.
        /// </summary>
        [JsonProperty("delivery", NullValueHandling = NullValueHandling.Ignore)]
        public Delivery Delivery { get; set; }

        /// <summary>
        /// This callback will occur when a message a page has sent has been read by the user.
        /// You can subscribe to this callback by selecting the message_reads field when setting up your webhook.
        /// </summary>
        [JsonProperty("read", NullValueHandling = NullValueHandling.Ignore)]
        public Read Read { get; set; }

        /// <summary>
        /// Gets or sets the referral.
        /// </summary>
        /// <value>
        /// The referral.
        /// </value>
        [JsonProperty("referral", NullValueHandling = NullValueHandling.Ignore)]
        public Referral Referral { get; set; }

        /// <summary>
        /// Gets or sets the account linking.
        /// </summary>
        /// <value>
        /// The account linking.
        /// </value>
        [JsonProperty("account_linking", NullValueHandling = NullValueHandling.Ignore)]
        public AccountLinking AccountLinking { get; set; }
        #endregion
    }
}
