using Newtonsoft.Json;

namespace SMEV.Adapter.Models.MessageContent
{
    public sealed class Status
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
