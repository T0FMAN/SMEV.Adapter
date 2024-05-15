using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Описание бизнес статуса запроса.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StatusParameter
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [JsonProperty("key")]
        public string? Key { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        [JsonProperty("value")]
        public string? Value { get; set; }
    }
}
