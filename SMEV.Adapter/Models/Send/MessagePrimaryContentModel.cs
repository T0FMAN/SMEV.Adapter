using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send
{
    public sealed class MessagePrimaryContentModel
    {
        public MessagePrimaryContentModel(string message) 
        {
            AnyMessage = message;
        }

        [JsonProperty("any")]
        public string AnyMessage { get; set; }
    }
}
