using Newtonsoft.Json;

namespace SMEV.Adapter.Models.MessageContent
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

        public ContentModel() { }

        /// <summary>
        /// Передаваемый контент
        /// </summary>
        [JsonProperty("content")]
        public Content Content { get; set; }
    }
}
