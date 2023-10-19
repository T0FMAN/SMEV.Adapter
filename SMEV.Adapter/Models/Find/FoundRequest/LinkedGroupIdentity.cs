using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find.FoundRequest
{
    public sealed class LinkedGroupIdentity
    {
        [JsonProperty("refClientId")]
        public string ReferenceClientId { get; set; }
        [JsonProperty("refGroupId")]
        public string ReferenceGroupId { get; set; }
    }
}
