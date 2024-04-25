using Newtonsoft.Json;

namespace SMEV.Adapter.Types.FindMethod
{
    /// <summary>
    /// Репрезентация найденного сообщения
    /// </summary>
    public sealed class FoundMessage
    {
        /// <summary>
        /// Метадата данных СМЭВ
        /// </summary>
        [JsonProperty("smevMetadata")]
        public SmevMetadata SmevMetadata { get; set; }
        /// <summary>
        /// Данные сообщения
        /// </summary>
        [JsonProperty("message")]
        public FoundMessageBody Message { get; set; }
    }
}
