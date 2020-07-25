// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System;
using System.Linq;

namespace ReflectSoftware.Facebook.Messenger.Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Gets the name of the json property.
        /// </summary>
        /// <param name="enumValue">The e.</param>
        /// <returns></returns>
        public static string GetJsonPropertyName(this Enum enumValue)
        {
            var member = enumValue.GetType().GetMember(enumValue.ToString()).First();
            var attribute = (JsonPropertyAttribute)member.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();

            return attribute != null ? attribute.PropertyName : enumValue.ToString();
        }
    }
}
