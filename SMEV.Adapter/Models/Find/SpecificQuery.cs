using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Класс контейнера, который включает варианты запроса сообщений.
    /// Существует два типа запроса: 
    /// <seealso cref="Find.MessagePeriodCriteria">по периоду времени</seealso> и 
    /// <seealso cref="Find.MessageClientIdCriteria">по идентификатору запроса</seealso>
    /// </summary>
    public sealed class SpecificQuery
    {
        /// <summary>
        /// Инициализация очереди запроса сообщений по временному периоду
        /// </summary>
        /// <param name="messagePeriod">Критерии временного диапазона, за который необходимо получить сообщения</param>
        /// <param name="countToReturn">Количество сообщений, удовлетворяющих критериям поиска, которое необходимо вернуть</param>
        /// <param name="offset">Размер смещения по списку сообщений или порядковый номер сообщения, с которого начнется отбор запросов</param>
        public SpecificQuery(MessagePeriodCriteria messagePeriod, int? countToReturn = null, int? offset = null)
        {
            MessagePeriodCriteria = messagePeriod;
            MessageCountToReturn = countToReturn;
            MessageOffset = offset;
        }

        /// <summary>
        /// Инициализация очереди запроса сообщений по идентифкатору запроса
        /// </summary>
        /// <param name="clientIdCriteria">Критерии идентификатора запроса, по которому необходимо получить сообщения</param>
        public SpecificQuery(MessageClientIdCriteria clientIdCriteria)
        {
            MessageClientIdCriteria = clientIdCriteria;
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
