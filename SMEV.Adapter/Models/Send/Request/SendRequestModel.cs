using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send.Request
{
    public sealed class SendRequestModel
    {
        public SendRequestModel(string itSystem, RequestMessage message)
        {
            ItSystem = itSystem;
            Message = message;
        }

        public SendRequestModel() { }

        [JsonProperty("itSystem")]
        public string ItSystem { get; set; }
        [JsonProperty("requestMessage")]
        public RequestMessage Message { get; set; }
    }
}
