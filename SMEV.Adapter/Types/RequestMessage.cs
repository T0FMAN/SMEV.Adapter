using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.MessageContent;
using SMEV.Adapter.Types.MessageMetadata;

namespace SMEV.Adapter.Types
{
    /// <summary>
    /// Информация о сообщении запроса
    /// </summary>
    public class RequestMessage : Message
    {
        /// <summary>
        /// Инициализация экземпляра <see cref="RequestMessage"/>
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="content"></param>
        public RequestMessage(RequestMetadata metadata, RequestContent content)
        {
            MessageType = MessageType.RequestMessageType;
            RequestMetadata = metadata;
            RequestContent = content;
        }

        /// <summary>
        /// Инициализация для де/сериализации
        /// </summary>
        public RequestMessage()
        {

        }

        /// <summary>
        /// Метаданные сообщения
        /// </summary>
        [JsonProperty("requestMetadata")]
        public RequestMetadata RequestMetadata { get; set; } = default!;

        /// <summary>
        /// Контент сообщения
        /// </summary>
        [JsonProperty("requestContent")]
        public RequestContent RequestContent { get; set; } = default!;
    }
}
