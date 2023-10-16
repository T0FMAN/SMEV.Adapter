using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find
{
    public sealed class SpecificQuery
    {
        [JsonProperty("messagePeriodCriteria")]
        public MessagePeriodCriteria? MessagePeriodCriteria { get; set; }
        [JsonProperty("messageClientIdCriteria")]
        public MessageClientIdCriteria? MessageClientIdCriteria { get; set; }
        [JsonProperty("messageClientIdCriteria")]
        public int? MessageCountToReturn { get; set; }
        [JsonProperty("messageClientIdCriteria")]
        public int? MessageOffset { get; set; }
    }
}
