using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Find.ResponseFound
{
    public sealed class Message
    {
        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
        [JsonProperty("requestMetadata")]
        public RequestMetadata RequestMetadata { get; set; }
        [JsonProperty("requestContent")]
        public ContentModel RequestContent { get; set; }
    }
}
