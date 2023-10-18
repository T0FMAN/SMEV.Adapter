using Newtonsoft.Json;

namespace SMEV.Adapter.Models.MessageContent
{
    /// <summary>
    /// Репрезентация головного элемента вложения
    /// </summary>
    public sealed class AttachmentHeader
    {
        /// <summary>
        /// Инициализация головного элемента вложения
        /// </summary>
        /// <param name="filePath"></param>
        public AttachmentHeader(string filePath)
        {
            FilePath = filePath;
        }

        public AttachmentHeader() { }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        [JsonProperty("filePath")]
        public string FilePath { get; set; }
    }
}
