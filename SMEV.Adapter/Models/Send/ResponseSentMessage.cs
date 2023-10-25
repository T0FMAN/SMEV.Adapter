using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send
{
    /// <summary>
    /// Класс для десериализации ответа от адаптера по методу <c>Send</c>
    /// </summary>
    public class ResponseSentMessage
    {
        /// <summary>
        /// Мнемоника ИС
        /// </summary>
        [JsonProperty("itSystem")]
        public string MnemonicIS { get; set; } = default!;
        /// <summary>
        /// ID сообщения
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; } = default!;
    }
}
