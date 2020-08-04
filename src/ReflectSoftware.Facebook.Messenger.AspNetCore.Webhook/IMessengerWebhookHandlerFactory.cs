// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
{
    public interface IMessengerWebhookHandlerFactory
    {
        IMessengerWebhookHandler CreateHandler(string verificationToken = null, string appSecret = null, bool ignoreSignature = false);
    }
}
