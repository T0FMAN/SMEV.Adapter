using Newtonsoft.Json;
using SMEV.Adapter.Enums;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Контейнер для шаблона поиска запросов по идентификатору запроса
    /// </summary>
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

        /// <summary>
        /// Инициализация шаблона 
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор запроса</param>
        /// <param name="requestType">Тип запроса</param>
        public MessageClientIdCriteria(string clientId, ClientCriteriaRequestType requestType)
        {
            ClientId = clientId;
            _requestType = requestType;
        }

        /// <summary>
        /// Уникальный идентификатор запроса
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        /// <summary>
        /// Тип запроса
        /// </summary>
        [JsonProperty("clientIdCriteria")]
        public string ClientIdCriteria 
        { 
            get 
            {
                RequestTypeDictionary.TryGetValue(_requestType, out var value);

                return value!; 
            }
        }
    }
}
