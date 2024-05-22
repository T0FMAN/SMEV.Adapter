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
        /// Инициализация контейнера шаблона поиска сообщений по уникальному идентификатору
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="requestType">Тип критерия поиска</param>
        public MessageClientIdCriteria(
            string clientId,
            ClientCriteriaRequestType requestType)
        {
            ClientId = clientId;
            ClientIdCriteria = requestType;
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
        public ClientCriteriaRequestType ClientIdCriteria { get; set; }
    }
}
