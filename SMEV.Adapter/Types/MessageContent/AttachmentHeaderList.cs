using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Контейнер с информацией о вложениях
    /// </summary>
    public sealed class AttachmentHeaderList
    {
        /// <summary>
        /// Инициализация контейнера с информацией о вложениях
        /// </summary>
        /// <param name="attachments">Список вложений</param>
        public AttachmentHeaderList(List<AttachmentHeader> attachments)
        {
            Attachments = attachments;
        }

        private AttachmentHeaderList() { }

        /// <summary>
        /// Список вложений
        /// </summary>
        [JsonProperty("attachmentHeader")]
        public List<AttachmentHeader> Attachments { get; set; } = default!;
    }
}
