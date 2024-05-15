using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Контент сообщения запроса
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RequestContent
    {
        /// <summary>
        /// <para>Бизнес данные запроса.</para>
        /// </summary>
        [JsonProperty("content")]
        public Content Content { get; set; } = default!;

        /// <summary>
        /// <para>Оригинальный запрос.</para>
        /// </summary>
        [JsonProperty("originalContent")]
        public string? OriginalContent { get; set; }
    }
}
