// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System;
using System.Linq;

namespace ReflectSoftware.Facebook.Messenger.Common.Extensions
{
    public static class JsonExtensions
    {
        public static string GetJsonPropertyName(this Enum e)
        {
            var member = e.GetType().GetMember(e.ToString()).First();
            var attribute = (JsonPropertyAttribute)member.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();

            return attribute != null ? attribute.PropertyName : e.ToString();
        }
    }
}
