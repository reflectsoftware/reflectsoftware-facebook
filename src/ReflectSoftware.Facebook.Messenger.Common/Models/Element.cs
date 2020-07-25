// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class Element 
    {
        /// <summary>
        /// Set of buttons that appear as call-to-actions
        /// Call-to-action items: 3 buttons
        /// </summary>
        [JsonProperty("buttons", NullValueHandling = NullValueHandling.Ignore)]
        public List<Button> Buttons { get; set; }
    }
}
