using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageMetadata
{
    /// <summary>
    /// Метаданные статусного сообщения
    /// </summary>
    public class StatusMetadata : Metadata
    {
        /// <summary>
        /// <para>
        /// Клиентский идентификатор сообщения, на который высылается статусный ответ.
        /// При получении ИС УВ статусного ответа данный элемент заполняется адаптером
        /// </para>
        /// </summary>
        [JsonProperty("originalClientId")]
        public string OriginalClientId { get; set; } = default!;
    }
}
