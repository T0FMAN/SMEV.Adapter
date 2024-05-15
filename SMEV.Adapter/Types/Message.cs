using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types
{
    /// <summary>
    /// Тело сообщения адаптера
    /// </summary>
    public class Message : IMessage
    {
        /// <inheritdoc/>
        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
    }
}
