// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReflectSoftware.Facebook.Messenger.Common.Models;
using System;

namespace ReflectSoftware.Facebook.Messenger.Common.Converters
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class AttachmentConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Attachment);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = default(Attachment);
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

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
