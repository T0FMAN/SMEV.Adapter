using Newtonsoft.Json;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Данные сообщения
    /// </summary>
    public class AdapterMessage
    {
        /// <summary>
        /// Метаданные сообщения
        /// </summary>
        [JsonProperty("smevMetadata")]
        public SmevMetadata SmevMetadata { get; set; } = default!;

        /// <summary>
        /// Тело сообщения
        /// </summary>
        [JsonProperty("message")]
        public IMessage Message { get; set; } = default!;
    }
}
