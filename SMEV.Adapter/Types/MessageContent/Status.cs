using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Бизнес статус запроса.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Status
    {
        /// <summary>
        /// Код бизнес статуса запроса.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = default!;

        /// <summary>
        /// Описание бизнес статуса запроса.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = default!;

        /// <summary>
        /// Статусные параметры запроса.
        /// </summary>
        [JsonProperty("parameter")]
        public List<StatusParameter>? Parameter { get; set; }
    }
}
