using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send.Response
{
    public sealed class ResponseMetadata
    {
        public ResponseMetadata(string clientId, string replyToClientId)
        {
            ClientId = clientId;
            ReplyToClientId = replyToClientId;
        }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("replyToClientId")]
        public string ReplyToClientId { get; set; }
    }
}
