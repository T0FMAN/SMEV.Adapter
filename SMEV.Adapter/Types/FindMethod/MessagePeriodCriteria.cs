using Newtonsoft.Json;

namespace SMEV.Adapter.Types.FindMethod
{
    /// <summary>
    /// Класс для контейнера временного диапазона, за который необходимо получить сообщения
    /// </summary>
    public sealed class MessagePeriodCriteria
    {
        private DateTimeOffset _from;
        private DateTimeOffset _to;

        private static readonly string mask = "yyyy-MM-dd'T'HH:mm:ssK";

        /// <summary>
        /// Инициализация временного диапазона
        /// </summary>
        /// <param name="fromDate">Метка времени, от которой искать сообщения</param>
        /// <param name="toDate">Метка времени, до которой искать сообщения</param>
        public MessagePeriodCriteria(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            _from = fromDate;
            _to = toDate;
        }

        /// <summary>
        /// Метка времени, от которой искать сообщения
        /// </summary>
        [JsonProperty("from")]
        public string FromDate
        {
            get { return _from.ToString(mask); }
        }
        /// <summary>
        /// Метка времени, до которой искать сообщения
        /// </summary>
        [JsonProperty("to")]
        public string ToDate
        {
            get { return _to.ToString(mask); }
        }
    }
}
