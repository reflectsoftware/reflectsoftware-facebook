// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class TemplatePayload : Payload
    {
        public TemplatePayload(string templateType)
        {
            TemplateType = templateType;
        }

        /// <summary>
        /// Template type generic, button or receipt
        /// </summary>
        [JsonProperty("template_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateType { get; private set; } 
    }
}
