using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Send.Request
{
    public sealed class RequestMessage
    {
        private MessageType _messageType = Enums.MessageType.RequestMessageType;

        public RequestMessage(RequestMetadata metadata, ContentModel content)
        {
            Metadata = metadata;
            Content = content;
        }

        public RequestMessage() { }

        [JsonProperty("messageType")]
        public string MessageType 
        { 
            get { return _messageType.ToString(); }
        }
        [JsonProperty("requestMetadata")]
        public RequestMetadata Metadata { get; set; }
        [JsonProperty("requestContent")]
        public ContentModel Content { get; set; }
    }
}
