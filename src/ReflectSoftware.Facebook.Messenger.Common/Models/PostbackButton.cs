using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class PostbackButton : Button
    {
        public PostbackButton() : base("postback")
        {
        }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public string Payload { get; set; }
    }
}
