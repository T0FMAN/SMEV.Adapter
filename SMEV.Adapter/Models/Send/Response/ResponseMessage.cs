using Newtonsoft.Json;
using SMEV.Adapter.Enums;

namespace SMEV.Adapter.Models.Send.Response
{
    public sealed class ResponseMessage
    {
        private MessageType _messageType = Enums.MessageType.ResponseMessageType;

        public ResponseMessage(ResponseMetadata metadata, SendContentModel content) 
        { 
            Metadata = metadata;
            Content = content;
        }

        public ResponseMessage() { }

        [JsonProperty("messageType")]
        public string MessageType
        {
            get { return _messageType.ToString(); }
        }
        [JsonProperty("responseMetadata")]
        public ResponseMetadata Metadata { get; set; }
        [JsonProperty("responseContent")]
        public SendContentModel Content { get; set; }
    }
}
