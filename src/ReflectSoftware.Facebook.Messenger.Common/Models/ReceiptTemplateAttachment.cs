// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// Use the Receipt Template with the Send API to send a order confirmation, with the transaction summary and description for each item.
    /// </summary>
    public class ReceiptTemplateAttachment : Attachment<ReceiptTemplatePayload>
    {
        public ReceiptTemplateAttachment() : base("template")
        {

        }

        public ReceiptTemplateAttachment(ReceiptTemplatePayload receipt) : this()
        {
            Payload = receipt;
        }
    }
}
