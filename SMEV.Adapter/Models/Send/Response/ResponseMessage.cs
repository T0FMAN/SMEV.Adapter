using Newtonsoft.Json;
using SMEV.Adapter.Enums;

namespace SMEV.Adapter.Models.Send.Response
{
    public sealed class ResponseMessage
    {
        public ResponseMessage(MessageType messageType, ResponseMetadata metadata, SendContentModel content) 
        { 
            MessageType = messageType;
            Metadata = metadata;
            Content = content;
        }

        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
        [JsonProperty("responseMetadata")]
        public ResponseMetadata Metadata { get; set; }
        [JsonProperty("responseContent")]
        public SendContentModel Content { get; set; }
    }
}
