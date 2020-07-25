using Newtonsoft.Json;
using ReflectSoftware.Facebook.Messenger.Common.Models;

namespace TestHarness
{
    partial class Program
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
}
