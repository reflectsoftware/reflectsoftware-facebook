// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Client
{
    public interface IClientMessengerFactory
    {
        IClientMessenger CreateClient(string accessToken, string version = "8.0");
    }
}
