using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Контент сообщения
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Content
    {
        /// <summary>
        /// Инициализация контейнера контента сообщения
        /// </summary>
        /// <param name="messagePrimaryContent">Контейнер, содержащий сообщения запроса</param>
        /// <param name="attachmentHeaderList">Контейнер с информацией о вложениях (необязательный параметр)</param>
        /// <param name="xmldSigSignatureType"></param>
        public Content(
            MessagePrimaryContent messagePrimaryContent, 
            AttachmentHeaderList? attachmentHeaderList = default,
            XmldSigSignatureType? xmldSigSignatureType = default)
        {
            MessagePrimaryContent = messagePrimaryContent;
            AttachmentHeaderList = attachmentHeaderList;
            PersonalSignature = xmldSigSignatureType;
        }

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

        /// <summary>
        /// Электронная подпись
        /// </summary>
        [JsonProperty("PersonalSignature")]
        public XmldSigSignatureType? PersonalSignature { get; set; }
    }
}
