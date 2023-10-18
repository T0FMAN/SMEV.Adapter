using Newtonsoft.Json;

namespace SMEV.Adapter.Models.MessageContent
{
    /// <summary>
    /// Класс представления контента сообщения
    /// </summary>
    public sealed class Content
    {
        /// <summary>
        /// Инициализация контейнера контента сообщения
        /// </summary>
        /// <param name="messagePrimaryContent">Контейнер, содержащий сообщения запроса</param>
        /// <param name="attachmentHeaderList">Контейнер с информацией о вложениях (необязательный параметр)</param>
        public Content(MessagePrimaryContent messagePrimaryContent, AttachmentHeaderList? attachmentHeaderList = null)
        {
            MessagePrimaryContent = messagePrimaryContent;
            AttachmentHeaderList = attachmentHeaderList;
        }

        public Content() { }

        /// <summary>
        /// Контейнер, содержащий сообщения запроса
        /// </summary>
        [JsonProperty("messagePrimaryContent")]
        public MessagePrimaryContent MessagePrimaryContent { get; set; }
        /// <summary>
        /// Контейнер с информацией о вложениях (необязательный параметр)
        /// </summary>
        [JsonProperty("attachmentHeaderList")]
        public AttachmentHeaderList? AttachmentHeaderList { get; set; }
    }
}
