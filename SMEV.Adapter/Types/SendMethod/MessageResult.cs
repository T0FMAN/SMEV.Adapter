using Newtonsoft.Json;

namespace SMEV.Adapter.Types.SendMethod
{
    /// <summary>
    /// Данные отправленного сообщения в адаптер
    /// </summary>
    public class MessageResult
    {
        /// <summary>
        /// Мнемоника ИС
        /// </summary>
        [JsonProperty("itSystem")]
        public string ItSystem { get; set; } = default!;
        /// <summary>
        /// ID отправленного сообщения
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; } = default!;
    }
}
