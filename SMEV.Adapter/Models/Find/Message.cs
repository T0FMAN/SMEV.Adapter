using Newtonsoft.Json;
using SMEV.Adapter.Enums;

namespace SMEV.Adapter.Models.Find
{
    public class Message
    {
        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
    }
}
