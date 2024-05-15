using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types
{
    /// <summary>
    /// Интерфейс для де/сериализации данных сообщения адаптера
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Тип сообщения
        /// </summary>
        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
    }
}
