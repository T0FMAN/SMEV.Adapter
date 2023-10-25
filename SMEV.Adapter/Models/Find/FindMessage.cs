using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.MessageContent;
using SMEV.Adapter.Models.MessageMetadata;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Репрезентация блока 'message' найденного сообщения
    /// </summary>
    public class FindMessage
    {
        /// <summary>
        /// JSON-конструктор
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="responseMetadata"></param>
        /// <param name="requestMetadata"></param>
        /// <param name="responseContent"></param>
        /// <param name="requestContent"></param>
        /// <param name="rejects"></param>
        [JsonConstructor]
        public FindMessage(
            MessageType messageType,
            Metadata? responseMetadata,
            Metadata? requestMetadata,
            ContentModel? responseContent,
            ContentModel? requestContent,
            List<Status>? rejects)
        {
            MessageType = messageType;
            Rejects = rejects;

            if (responseMetadata is not null && responseContent is not null)
            {
                Content = responseContent;
                Metadata = responseMetadata;
            }
            if (requestMetadata is not null && requestContent is not null)
            {
                Content = requestContent;
                Metadata = requestMetadata;
            }
        }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public MessageType MessageType { get; set; }
        /// <summary>
        /// Метаданные сообщения
        /// </summary>
        public Metadata Metadata { get; set; }
        /// <summary>
        /// Контент сообщения
        /// </summary>
        public ContentModel Content { get; set; }
        /// <summary>
        /// Ошибки в случае отклонения сообщения адаптером
        /// </summary>
        public List<Status>? Rejects { get; set; }
    }
}
