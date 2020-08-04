// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Client
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ReflectSoftware.Facebook.Messenger.Client.IClientMessengerFactory" />
    public class ClientMessengerFactory : IClientMessengerFactory
    {
        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        public IClientMessenger CreateClient(string accessToken, string version = "8.0")
        {
            return new ClientMessenger(accessToken, version);
        }
    }
}
