using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageMetadata
{
    /// <summary>
    /// Реперзентация ссылочной группы, по которой проходит идентификация
    /// </summary>
    public sealed class LinkedGroupIdentity
    {
        /// <summary>
        /// Ссылаемый уникальный идентификатор
        /// </summary>
        [JsonProperty("refClientId")]
        public string ReferenceClientId { get; set; }
        /// <summary>
        /// Ссылаемый идентификатор группы
        /// </summary>
        [JsonProperty("refGroupId")]
        public string ReferenceGroupId { get; set; }
    }
}
