// ReflectSoftware.Facebook
// Copyright (c) 2019 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    /// <summary>
    // This callback will occur when the Linked Account or Unlink Account call-to-action have been tapped. 
    // The status parameter is set to inform you whether the user linked or unlinked their account. The authorization_code 
    // is a pass-through parameter. allowing you to match the business user entity to the page-scoped ID (PSID) of the sender.
    /// </summary>
    public class AccountLinking
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("authorization_code", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizationCode { get; set; }
    }
}
