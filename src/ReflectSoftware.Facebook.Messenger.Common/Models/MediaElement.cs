using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class MediaElement : Element
    {
        [JsonProperty("media_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaType { get; set; }

        [JsonProperty("attachment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentId { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        public MediaElement(string type)
        {
            MediaType = type;
        }
    }
}
