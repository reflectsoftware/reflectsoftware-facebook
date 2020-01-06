// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System;
using System.Linq;

namespace ReflectSoftware.Facebook.Messenger.Common.Converters
{
    public class EnumValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var member = value.GetType().GetMember(value.ToString()).First();
            var attribute = (JsonPropertyAttribute)member.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();
            var result = value.ToString();
            if (attribute != null)
            {
                result = attribute.PropertyName;
            }

            serializer.Serialize(writer, result);
        }
    }
}
