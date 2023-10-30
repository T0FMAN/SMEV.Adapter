using Newtonsoft.Json;
using SMEV.Adapter.Enums;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Контейнер для шаблона поиска запросов по идентификатору запроса
    /// </summary>
    public sealed class MessageClientIdCriteria
    {
        /// <summary>
        /// Текущий тип запроса для критерия поиска
        /// </summary>
        public ClientCriteriaRequestType RequestType { private get; set; }

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
        /// Инициализация контейнера шаблона поиска сообщений по уникальному идентификатору
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="isReqByReq">Включить получение сообщений запросов по клиентскому идентификатору запроса</param>
        /// <param name="isResByRes">Включить получение сообщений ответов на запрос по клиентскому идентификатору ответа</param>
        /// <param name="isResByReq">Включить получение сообщений ответов на запрос по клиентскому идентификатору запроса</param>
        public MessageClientIdCriteria(string clientId, bool isReqByReq, bool isResByRes, bool isResByReq)
        {
            ClientId = clientId;
            IsReqByReq = isReqByReq;
            IsResByRes = isResByRes;
            IsResByReq = isResByReq;
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
        /// <summary>
        /// Включить сообщения запроса на запрос
        /// </summary>
        [JsonIgnore]
        public bool IsReqByReq { get; set; }
        /// <summary>
        /// Включить сообщения ответа на ответ
        /// </summary>
        [JsonIgnore]
        public bool IsResByRes { get; set; }
        /// <summary>
        /// Включить сообщения ответа на запрос
        /// </summary>
        [JsonIgnore]
        public bool IsResByReq { get; set; }
    }
}
