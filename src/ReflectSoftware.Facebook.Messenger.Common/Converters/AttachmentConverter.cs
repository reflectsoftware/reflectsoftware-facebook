// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReflectSoftware.Facebook.Messenger.Common.Interfaces;
using ReflectSoftware.Facebook.Messenger.Common.Models;
using System;

namespace ReflectSoftware.Facebook.Messenger.Common.Converters
{
    public class AttachmentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IAttachment);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = default(IAttachment);
            var attachment = JObject.Load(reader);
            var type = (attachment["type"] as JValue).Value.ToString();
            switch(type)
            {
                case "image":
                    result = new ImageAttachment();
                    break;
                case "audio":
                    result = new AudioAttachment();
                    break;
                case "video":
                    result = new VideoAttachment();
                    break;
                case "file":
                    result = new FileAttachment();
                    break;
                case "location":
                    result = new LocationAttachment();
                    break;
                case "fallback":
                    result = new FallbackAttachment();
                    break;
                case "template":
                    var templateType = (attachment["payload"]["template_type"] as JValue).Value.ToString();
                    switch(templateType)
                    {
                        case "generic":
                            result = new GenericTemplateAttachment();
                            break;
                        case "button":
                            result = new ButtonTemplateAttachment();
                            break;
                        case "receipt":
                            result = new ReceiptTemplateAttachment();
                            break;
                    }
                    break;
            }
            serializer.Populate(attachment.CreateReader(), result);

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
