using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class MediaTemplatePayload : TemplatePayload
    {
        public MediaTemplatePayload() : base("media")
        {
        }

        public MediaTemplatePayload(List<MediaElement> elements) : this()
        {
            Elements = elements;
        }

        // <summary>
        /// Data for each bubble in message
        /// Bubbles per message (horizontal scroll): 10 elements
        /// </summary>
        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public List<MediaElement> Elements { get; set; }
    }
}

