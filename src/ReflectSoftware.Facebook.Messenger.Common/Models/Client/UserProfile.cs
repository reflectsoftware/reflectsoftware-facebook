// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Client
{
    public class UserProfile
    {
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Firstname { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Lastname { get; set; }

        [JsonProperty("profile_pic", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfilePicture { get; set; }

        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Timezone { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("is_payment_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPaymentEnabled { get; set; }
    }
}
