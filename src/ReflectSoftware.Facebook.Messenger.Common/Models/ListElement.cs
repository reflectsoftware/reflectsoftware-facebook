// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class ListElement : GenericElement
    {
        [JsonProperty("default_action", NullValueHandling = NullValueHandling.Ignore)]
        public ListButton DefaultAction { get; set; }
    }
}
