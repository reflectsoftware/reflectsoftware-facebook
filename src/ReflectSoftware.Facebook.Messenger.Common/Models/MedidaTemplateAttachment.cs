// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class MedidaTemplateAttachment : Attachment<MediaTemplatePayload>
    {
        public MedidaTemplateAttachment() : base("template")
        {

        }

        public MedidaTemplateAttachment(List<MediaElement> elements) : this()
        {
            Payload = new MediaTemplatePayload(elements);
        }
    }
}

