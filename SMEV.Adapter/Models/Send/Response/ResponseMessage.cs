using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Send.Response
{
    /// <summary>
    /// Репрезентация тела сообщения-ответа
    /// </summary>
    public sealed class ResponseMessage
    {
        private readonly MessageType _messageType = Enums.MessageType.ResponseMessageType;

        /// <summary>
        /// Инициализация тела сообщения-ответа
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="content"></param>
        public ResponseMessage(ResponseMetadata metadata, ContentModel content) 
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
        [JsonProperty("responseMetadata")]
        public ResponseMetadata Metadata { get; set; }
        /// <summary>
        /// Контент тела сообщения
        /// </summary>
        [JsonProperty("responseContent")]
        public ContentModel Content { get; set; }
    }
}
