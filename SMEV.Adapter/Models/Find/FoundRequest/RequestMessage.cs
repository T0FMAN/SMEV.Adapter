using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Find.FoundRequest
{
    public sealed class RequestMessage
    {
        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
        [JsonProperty("requestMetadata")]
        public FindRequestMetadata? RequestMetadata { get; set; }
        [JsonProperty("requestContent")]
        public ContentModel RequestContent { get; set; }
    }
}
