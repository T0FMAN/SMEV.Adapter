using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageMetadata
{
    /// <summary>
    /// Формирование Адаптером СМЭВ кода транзакции
    /// </summary>
    public class CreateGroupIdentity
    {
        /// <summary>
        /// <para>Код ФРГУ государственной услуги либо государственной функции</para>
        /// </summary>
        [JsonProperty("FRGUServiceCode")]
        public string? FrguServiceCode { get; set; }

        /// <summary>
        /// <para>Расширенные сведения об услуге или функции</para>
        /// </summary>
        [JsonProperty("FRGUServiceDescription")]
        public string? FrguServiceDescription { get; set; }

        /// <summary>
        /// <para>Расширенные сведения о потребителе услуги или функции</para>
        /// </summary>
        [JsonProperty("FRGUServiceRecipientDescription")]
        public string? FrguServiceRecipientDescription { get; set; }
    }
}
