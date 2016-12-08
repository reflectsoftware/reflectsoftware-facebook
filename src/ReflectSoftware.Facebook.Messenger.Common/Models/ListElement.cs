using Newtonsoft.Json;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class ListElement : GenericElement
    {
        [JsonProperty("default_action")]
        public ListButton DefaultAction { get; set; }
    }
}
