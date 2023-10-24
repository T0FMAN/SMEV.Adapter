using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.Find.FoundRequest;
using SMEV.Adapter.Models.Find.FoundResponse;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Класс для десериализации ответа JSON-блока 'message'
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Тип сообщения
        /// </summary>
        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
        /// <summary>
        /// В случае статуса 'отклонено' десериализация списка включающих в сообщение статусов
        /// </summary>
        [JsonProperty("rejects")]
        public List<Status>? Rejects { get; set; }
    }
}
