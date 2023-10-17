using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send
{
    public sealed class SendContentModel
    {
        public SendContentModel(ContentModel content) 
        { 
            Content = content;
        }

        public SendContentModel() { }

        [JsonProperty("content")]
        public ContentModel Content { get; set; }
    }
}
