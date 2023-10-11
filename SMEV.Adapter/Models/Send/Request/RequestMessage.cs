using Newtonsoft.Json;
using SMEV.Adapter.Enums;

namespace SMEV.Adapter.Models.Send.Request
{
    public sealed class RequestMessage
    {
        public RequestMessage(MessageType messageType, RequestMetadata metadata, SendContentModel content) 
        {
            MessageType = messageType;
            Metadata = metadata;
            Content = content;
        }

        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
        [JsonProperty("requestMetadata")]
        public RequestMetadata Metadata { get; set; }
        [JsonProperty("requestContent")]
        public SendContentModel Content { get; set; }
    }
}
