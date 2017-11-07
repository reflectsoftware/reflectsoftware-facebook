// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using ReflectSoftware.Facebook.Messenger.Common.Interfaces;
using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public abstract class TemplatePayload : IPayload
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
