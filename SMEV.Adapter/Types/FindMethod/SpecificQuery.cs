using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types.FindMethod
{
    /// <summary>
    /// Класс контейнера, который включает варианты запроса сообщений.
    /// Существует два типа запроса: 
    /// <seealso cref="MessagePeriodCriteria">по периоду времени</seealso> и 
    /// <seealso cref="MessageClientIdCriteria">по идентификатору запроса</seealso>
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class SpecificQuery
    {
        /// <summary>
        /// Инициализация очереди запроса сообщений по временному периоду
        /// </summary>
        /// <param name="fromDate">Метка времени, от которой искать сообщения</param>
        /// <param name="toDate">Метка времени, до которой искать сообщения</param>
        /// <param name="countToReturn">Количество сообщений, удовлетворяющих критериям поиска, которое необходимо вернуть</param>
        /// <param name="offset">Размер смещения по списку сообщений или порядковый номер сообщения, с которого начнется отбор запросов</param>
        public SpecificQuery(DateTimeOffset fromDate, DateTimeOffset toDate, int? countToReturn = null, int? offset = null)
        {
            MessagePeriodCriteria = new MessagePeriodCriteria(fromDate, toDate);
            MessageCountToReturn = countToReturn;
            MessageOffset = offset;
        }

        /// <summary>
        /// Инициализация очереди запроса сообщений по идентифкатору запроса.
        /// По умолчанию в критериях типа сообщений стоят все <c>true</c> значения, что означает
        /// включение в поиск сообщений ответов и запросов по всем типам из <see cref="ClientCriteriaRequestType"/>)
        /// </summary>
        /// <param name="clientId">Критерии идентификатора запроса, по которому необходимо получить сообщения</param>
        /// <param name="requestType">Тип критерия запроса</param>
        public SpecificQuery(string clientId, ClientCriteriaRequestType requestType)
        {
            MessageClientIdCriteria = new MessageClientIdCriteria(clientId, requestType);
        }

        /// <summary>
        /// Критерии временного диапазона, за который необходимо получить сообщения
        /// </summary>
        [JsonProperty("messagePeriodCriteria")]
        public MessagePeriodCriteria? MessagePeriodCriteria { get; set; }
        /// <summary>
        /// Критерии идентификатора запроса, по которому необходимо получить сообщения
        /// </summary>
        [JsonProperty("messageClientIdCriteria")]
        public MessageClientIdCriteria? MessageClientIdCriteria { get; set; }
        /// <summary>
        /// Количество сообщений, удовлетворяющих критериям поиска, которое необходимо вернуть
        /// </summary>
        [JsonProperty("messageCountToReturn")]
        public int? MessageCountToReturn { get; set; }
        /// <summary>
        /// Размер смещения по списку сообщений или порядковый номер сообщения, с которого начнется отбор запросов
        /// </summary>
        [JsonProperty("messageOffset")]
        public int? MessageOffset { get; set; }
    }
}
