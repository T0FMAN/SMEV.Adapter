using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Класс контейнера контента
    /// </summary>
    public sealed class ContentModel
    {
        /// <summary>
        /// Инициализация контейнера контента
        /// </summary>
        /// <param name="content">Передаваемый контент</param>
        public ContentModel(Content content)
        {
            Content = content;
        }

        /// <summary>
        /// Передаваемый контент
        /// </summary>
        [JsonProperty("content")]
        public Content? Content { get; set; }
        /// <summary>
        /// Статус сообщения (генерируется только при десерализации ответа)
        /// </summary>
        [JsonProperty("status")]
        public Status? Status { get; private set; }
    }
}
