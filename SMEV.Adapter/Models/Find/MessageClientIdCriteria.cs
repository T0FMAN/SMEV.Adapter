using Newtonsoft.Json;
using SMEV.Adapter.Enums;

namespace SMEV.Adapter.Models.Find
{
    public sealed class MessageClientIdCriteria
    {
        private ClientCriteriaRequestType _requestType;

        private static readonly Dictionary<ClientCriteriaRequestType, string> RequestTypeDictionary;

        static MessageClientIdCriteria()
        {
            RequestTypeDictionary = new()
            {
                { ClientCriteriaRequestType.RequestByRequest, "GET_REQUEST_BY_REQUEST_CLIENTID" },
                { ClientCriteriaRequestType.ResponseByResponse, "GET_RESPONSE_BY_RESPONSE_CLIENTID" },
                { ClientCriteriaRequestType.ResponseByRequest, "GET_RESPONSE_BY_REQUEST_CLIENTID" }
            };
        }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("clientIdCriteria")]
        public string ClientIdCriteria 
        { 
            get 
            {
                RequestTypeDictionary.TryGetValue(_requestType, out var value);

                return value!; 
            } 
            set 
            {
                ClientCriteriaRequestType requestType = default;

                foreach (var pair in RequestTypeDictionary)
                {
                    if (pair.Value == value)
                        requestType = pair.Key;
                }

                _requestType = requestType; 
            } 
        }
    }
}
