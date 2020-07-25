// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Enums
{
    public enum MessageTag
    {
        [JsonProperty("CONFIRMED_EVENT_UPDATE")]
        ConfirmEventUpdate = 0,

        [JsonProperty("POST_PURCHASE_UPDATE")]
        PostPurchaseUpdate,

        [JsonProperty("ACCOUNT_UPDATE")]
        AccountUpate,

        [JsonProperty("HUMAN_AGENT")]
        HumanAgent

    }
}
