// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Client
{
    public class MessageSent
    {
        /// <summary>
        /// Custom string that will be re-delivered to webhook listeners
        /// metadata has a 1000 character limit
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }

        /// <summary>
        /// Quick Replies provide a new way to present buttons to the user. Quick Replies appear prominently above the composer, with the keyboard less prominent. When a quick reply is tapped, the message is sent in the conversation with developer-defined metadata in the callback. Also, the buttons are dismissed preventing the issue where users could tap on buttons attached to old messages in a conversation.
        /// quick_replies is limited to 10
        /// </summary>
        [JsonProperty("quick_replies", NullValueHandling = NullValueHandling.Ignore)]
        public List<QuickReply> QuickReplies { get; set; }
    }
}
