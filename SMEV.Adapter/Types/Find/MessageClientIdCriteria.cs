using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Контейнер для шаблона поиска запросов по идентификатору запроса
    /// </summary>
    public sealed class MessageClientIdCriteria
    {
        /// <summary>
        /// Тип запроса для критерия поиска
        /// </summary>
        private ClientCriteriaRequestType RequestType { get; set; }

        private static readonly Dictionary<ClientCriteriaRequestType, string> RequestTypeDictionary = new()
        {
            { ClientCriteriaRequestType.RequestByRequest, "GET_REQUEST_BY_REQUEST_CLIENTID" },
            { ClientCriteriaRequestType.ResponseByResponse, "GET_RESPONSE_BY_RESPONSE_CLIENTID" },
            { ClientCriteriaRequestType.ResponseByRequest, "GET_RESPONSE_BY_REQUEST_CLIENTID" }
        };

        /// <summary>
        /// Инициализация контейнера шаблона поиска сообщений по уникальному идентификатору
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="requestType">Тип критерия поиска</param>
        public MessageClientIdCriteria(
            string clientId,
            ClientCriteriaRequestType requestType)
        {
            ClientId = clientId;
            RequestType = requestType;
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
                RequestTypeDictionary.TryGetValue(RequestType, out var value);

                return value!;
            }
        }
    }
}
