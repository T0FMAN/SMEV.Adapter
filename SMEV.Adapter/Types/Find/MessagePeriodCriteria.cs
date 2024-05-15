using Newtonsoft.Json;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Контейнер временного диапазона, за который необходимо получить сообщения
    /// </summary>
    public sealed class MessagePeriodCriteria
    {
        private readonly DateTimeOffset _from;
        private readonly DateTimeOffset? _to;

        private static readonly string mask = "yyyy-MM-dd'T'HH:mm:ssK";

        /// <summary>
        /// Инициализация временного диапазона
        /// </summary>
        /// <param name="fromDate">Метка времени, от которой искать сообщения</param>
        /// <param name="toDate">Метка времени, до которой искать сообщения</param>
        public MessagePeriodCriteria(
            DateTimeOffset fromDate,
            DateTimeOffset? toDate = default)
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
            get
            {
                if (_to is null)
                    return DateTimeOffset.UtcNow.ToString(mask);
                else
                    return _to.Value.ToString(mask);
            }
        }
    }
}
