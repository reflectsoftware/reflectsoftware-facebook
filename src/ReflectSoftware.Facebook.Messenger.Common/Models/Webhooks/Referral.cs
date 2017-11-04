// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks
{
    /// <summary>
    /// This callback will occur when an m.me link is used with a referral param and only in a case this user already has a 
    /// thread with this bot (for new threads see Postback Event). See also full guide on m.me links. 
    /// To start receiving these events you need to subscribe to messaging_referral in webhook settings of your app.
    /// An m.me link with an added parameter looks like this: http://m.me/mybot?ref=myparam. The value of the ref parameter will be passed to the server via webhook.
    /// </summary>
    public class Referral
    {
        [JsonProperty("ref", NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
