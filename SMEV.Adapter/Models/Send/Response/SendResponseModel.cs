using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send.Response
{
    public sealed class SendResponseModel
    {
        public SendResponseModel(string itSystem, ResponseMessage message) 
        {
            ItSystem = itSystem;
            ResponseMessage = message;
        }

        [JsonProperty("itSystem")]
        public string ItSystem { get; set; }
        [JsonProperty("responseMessage")]
        public ResponseMessage ResponseMessage { get; set; }
    }
}
