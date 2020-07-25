using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class CallMeButton : Button
    {
        public CallMeButton() : base("phone_number")
        {
        }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
    }
}

