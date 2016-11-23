// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// Use the Generic Template with the Send API to send a horizontal scrollable carousel of items, each composed of an image attachment, short description and buttons to request input from the user.
    /// </summary>
    public class GenericTemplateAttachment : Attachment<GenericTemplatePayload>
    {
        public GenericTemplateAttachment() : base("template")
        {

        }

        public GenericTemplateAttachment(List<GenericElement> elements) : this()
        {
            Payload = new GenericTemplatePayload(elements);
        }
    }
}
