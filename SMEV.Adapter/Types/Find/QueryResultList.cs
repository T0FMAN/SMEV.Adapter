using Newtonsoft.Json;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Ответ на запрос поиска сообщений по критериям в адаптере
    /// </summary>
    public sealed class QueryResultList
    {
        /// <summary>
        /// Список сообщений, удовлетворяющим критериям поиска
        /// </summary>
        [JsonProperty("queryResult")]
        public List<AdapterMessage> QueryResult { get; set; } = default!;
    }
}
