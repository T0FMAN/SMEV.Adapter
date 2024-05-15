using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageMetadata
{
    /// <summary>
    /// Метаданные сообщения ответа
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ResponseMetadata : Metadata
    {
        /// <summary>
        /// <para>
        /// Клиентский идентификатор запроса, на который высылается ответ.
        /// Данный элемент заполняется ИС УВ при отправке ответа на запрос в адаптер.
        /// При получении ИС УВ ответа на запрос из адаптера данный элемент заполняется адаптером.</para>
        /// </summary>
        [JsonProperty("replyToClientId")]
        public string ReplyToClientId { get; set; } = default!;

        /// <summary>
        /// <para>Строка replyTo из оригинального запроса</para>
        /// </summary>
        [JsonProperty("replyTo")]
        public string? ReplyTo { get; set; }
    }
}
