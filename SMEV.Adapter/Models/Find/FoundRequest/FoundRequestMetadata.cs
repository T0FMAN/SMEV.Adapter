using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find.FoundRequest
{
    public sealed class FoundRequestMetadata
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("linkedGroupIdentity")]
        public LinkedGroupIdentity LinkedGroupIdentity { get; set; }
        [JsonProperty("testMessage")]
        public bool? TestMessage { get; set; }
        [JsonProperty("transactionCode")]
        public string TransactionCode { get; set; }
    }
}
