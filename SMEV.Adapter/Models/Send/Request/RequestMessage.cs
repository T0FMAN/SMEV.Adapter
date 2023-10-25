using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Send.Request
{
    /// <summary>
    /// Репрезентация тела сообщения-запроса
    /// </summary>
    public sealed class RequestMessage
    {
        private readonly MessageType _messageType = Enums.MessageType.RequestMessageType;

        /// <summary>
        /// Инициализация тела сообщения-запроса
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="content"></param>
        public RequestMessage(RequestMetadata metadata, ContentModel content)
        {
            Metadata = metadata;
            Content = content;
        }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        [JsonProperty("messageType")]
        public string MessageType 
        { 
            get { return _messageType.ToString(); }
        }
        /// <summary>
        /// Метаданные тела сообщения
        /// </summary>
        [JsonProperty("requestMetadata")]
        public RequestMetadata Metadata { get; set; }
        /// <summary>
        /// Контент тела сообщения
        /// </summary>
        [JsonProperty("requestContent")]
        public ContentModel Content { get; set; }
    }
}
