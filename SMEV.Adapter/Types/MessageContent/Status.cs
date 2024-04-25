using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Статус сообщения
    /// </summary>
    public sealed class Status
    {
        /// <summary>
        /// Код статуса
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// Описание статуса сообщения
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
