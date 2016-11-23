// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// Use the Button Template with the Send API to send a text and buttons attachment to request input from the user. The buttons can open a URL, or make a back-end call to your webhook.
    /// </summary>
    public class ButtonTemplateAttachment : Attachment<ButtonTemplatePayload>
    {
        public ButtonTemplateAttachment() : base("template")
        {

        }

        /// <summary>
        /// Use the Button Template with the Send API to send a text and buttons attachment to request input from the user. The buttons can open a URL, or make a back-end call to your webhook.
        /// </summary>
        /// <param name="text">text must be UTF-8 and has a 320 character limit</param>
        /// <param name="buttons">buttons is limited to 3</param>
        public ButtonTemplateAttachment(string text, List<Button> buttons) : this()
        {
            Payload = new ButtonTemplatePayload(text, buttons);
        }
    }
}
