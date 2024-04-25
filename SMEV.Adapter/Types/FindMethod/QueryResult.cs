using Newtonsoft.Json;

namespace SMEV.Adapter.Types.FindMethod
{
    /// <summary>
    /// Класс для десериализации полученной очереди сообщений методом <c>Find</c>
    /// </summary>
    public sealed class QueryResult
    {
        /// <summary>
        /// Список найденных сообщений из очереди
        /// </summary>
        [JsonProperty("queryResult")]
        public List<FoundMessage> FoundMessages { get; set; } = new List<FoundMessage>();
    }
}
