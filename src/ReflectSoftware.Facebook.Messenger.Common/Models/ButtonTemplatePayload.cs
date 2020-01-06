// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// Use the Button Template with the Send API to send a text and buttons attachment to request input from the user. The buttons can open a URL, or make a back-end call to your webhook.
    /// </summary>
    public class ButtonTemplatePayload : TemplatePayload
    {
        public ButtonTemplatePayload() : base("button")
        {
        }

        /// <summary>
        /// Use the Button Template with the Send API to send a text and buttons attachment to request input from the user. The buttons can open a URL, or make a back-end call to your webhook.
        /// </summary>
        /// <param name="text">text must be UTF-8 and has a 320 character limit</param>
        /// <param name="buttons">buttons is limited to 3</param>
        public ButtonTemplatePayload(string text, List<Button> buttons) :this()
        {
            Text = text;
            Buttons = buttons;
        }

        /// <summary>
        /// Text that appears in main body
        /// text must be UTF-8 and has a 320 character limit
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// Set of buttons that appear as call-to-actions
        /// buttons is limited to 3
        /// </summary>
        [JsonProperty("buttons", NullValueHandling = NullValueHandling.Ignore)]
        public List<Button> Buttons { get; set; }
    }
}
