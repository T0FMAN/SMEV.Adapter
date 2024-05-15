using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.MessageMetadata;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Статусное сообщение
    /// </summary>
    public class StatusMessage : Message
    {
        /// <summary>
        /// Метаданные статусного сообщения
        /// </summary>
        [JsonProperty("statusMetadata")]
        public StatusMetadata StatusMetadata { get; set; } = default!;

        /// <summary>
        /// <para>Тип статусного сообщения</para>
        /// </summary>
        [JsonProperty("status")]
        public StatusMessageCategory Status { get; set; }

        /// <summary>
        /// <para>Описание статуса</para>
        /// </summary>
        [JsonProperty("details")]
        public string Details { get; set; } = default!;

        /// <summary>
        /// <para>Метка времени формирования статуса</para>
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
