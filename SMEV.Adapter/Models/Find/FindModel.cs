using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find
{
    public class FindModel
    {
        [JsonProperty("itSystem")]
        public string ItSystem { get; set; }
        [JsonProperty("specificQuery")]
        public SpecificQuery SpecificQuery { get; set; }
    }
}
