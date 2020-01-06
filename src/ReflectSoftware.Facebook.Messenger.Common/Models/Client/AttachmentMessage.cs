// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Client
{
    public class AttachmentMessage : MessageSent
    {
        public AttachmentMessage()
        {
        }

        public AttachmentMessage(Attachment attachment)
        {
            Attachment = attachment;
        }

        /// <summary>
        /// attachment is used to send messages with images or Structured Messages
        /// </summary>
        [JsonProperty("attachment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Attachment Attachment { get; set; }
    }
}
