using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send
{
    public sealed class ResponseSendAdapter
    {
        [JsonProperty("itSystem")]
        public string ItSystem { get; set; }
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
    }
}
