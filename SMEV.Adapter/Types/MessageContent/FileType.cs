using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Передаваемый файл
    /// </summary>
    public class FileType
    {
        /// <summary>
        /// <para>Наименование файла.</para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// <para>Идентификатор паспорта вложения.</para>
        /// </summary>
        [JsonProperty("passportId")]
        public string PassportId { get; set; } = default!;
    }
}
