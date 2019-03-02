// ReflectSoftware.Facebook
// Copyright (c) 2019 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Client
{
    public class TextMessage : MessageSent
    {
        public TextMessage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">text is used when sending a text message, must be UTF-8 and has a 320 character limit</param>
        public TextMessage(string text)
        {
            Text = text;
        }

        /// <summary>
        /// text is used when sending a text message, must be UTF-8 and has a 320 character limit
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }
}
