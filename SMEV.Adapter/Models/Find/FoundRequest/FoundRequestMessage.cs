using Newtonsoft.Json;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Find.FoundRequest
{
    public class FoundRequestMessage : Message
    {
        [JsonProperty("requestMetadata")]
        public FoundRequestMetadata RequestMetadata { get; set; }
        [JsonProperty("requestContent")]
        public ContentModel RequestContent { get; set; }
    }
}
