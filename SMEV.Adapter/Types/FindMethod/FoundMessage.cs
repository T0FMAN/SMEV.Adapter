using Newtonsoft.Json;

namespace SMEV.Adapter.Types.FindMethod
{
    /// <summary>
    /// Репрезентация найденного сообщения
    /// </summary>
    public sealed class FoundMessage
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
        public FoundMessageBody Message { get; set; } = default!;
    }
}
