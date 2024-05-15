using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.MessageContent;
using SMEV.Adapter.Types.MessageMetadata;

namespace SMEV.Adapter.Types
{
    /// <summary>
    /// Информация о сообщении ответа
    /// </summary>
    public class ResponseMessage : Message
    {
        /// <summary>
        /// Инициализация экземпляра <see cref="ResponseMessage"/>
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="content"></param>
        public ResponseMessage(ResponseMetadata metadata, ResponseContent content)
        {
            MessageType = MessageType.ResponseMessageType;
            ResponseMetadata = metadata;
            ResponseContent = content;
        }

        /// <summary>
        /// Инициализация для де/сериализации
        /// </summary>
        public ResponseMessage()
        {

        }

        /// <summary>
        /// Метаданные сообщения
        /// </summary>
        [JsonProperty("responseMetadata")]
        public ResponseMetadata ResponseMetadata { get; set; } = default!;

        /// <summary>
        /// Контент сообщения
        /// </summary>
        [JsonProperty("responseContent")]
        public ResponseContent ResponseContent { get; set; } = default!;
    }
}
