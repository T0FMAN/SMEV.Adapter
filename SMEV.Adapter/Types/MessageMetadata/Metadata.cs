using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageMetadata
{
    /// <summary>
    /// Метаданные сообщения
    /// </summary>
    public class Metadata : IMetadata
    {
        /// <inheritdoc/>
        [JsonProperty("clientId")]
        public string ClientId { get; set; } = default!;
    }
}
