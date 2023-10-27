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
        /// 
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
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="isReqByReq"></param>
        /// <param name="isResByRes"></param>
        /// <param name="isResByReq"></param>
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
