using Newtonsoft.Json;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Find.FoundResponse
{
    public class FoundResponseMessage : Message
    {
        [JsonProperty("responseMetadata")]
        public FoundResponseMetadata ResponseMetadata { get; set; }
        [JsonProperty("responseContent")]
        public ContentModel ResponseContent { get; set; }
    }
}
