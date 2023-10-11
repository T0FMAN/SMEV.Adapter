using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send.Request
{
    public sealed class RequestMetadata
    {
        public RequestMetadata(string clientId, bool? testMessage)
        {
            ClientId = clientId;
            TestMessage = testMessage;
        }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("testMessage")]
        public bool? TestMessage { get; set; }
    }
}
