using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Контент сообщения ответа
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ResponseContent
    {
        /// <summary>
        /// <para>Бизнес данные ответа на запрос.</para>
        /// </summary>
        [JsonProperty("content")]
        public Content? Content { get; set; }

        /// <summary>
        /// <para>Отклонение запроса.</para>
        /// </summary>
        [JsonProperty("rejects")]
        public List<Reject>? Rejects { get; set; }

        /// <summary>
        /// <para>Бизнес статус запроса.</para>
        /// </summary>
        [JsonProperty("status")]
        public Status? Status { get; set; }

        /// <summary>
        /// <para>Оригинальный ответ.</para>
        /// </summary>
        [JsonProperty("originalContent")]
        public string? OriginalContent { get; set; }
    }
}
