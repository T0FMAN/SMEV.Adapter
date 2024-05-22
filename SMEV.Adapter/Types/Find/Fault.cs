using Newtonsoft.Json;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Данные ошибки
    /// </summary>
    public class Fault
    {
        /// <summary>
        /// <para>Код ошибки, генерируемый Адаптером СМЭВ либо возвращаемый СМЭВ 3</para>
        /// </summary>
        [JsonProperty("code")]
        public string? Code { get; set; }

        /// <summary>
        /// <para>Описание ошибки, генерируемое Адаптером СМЭВ либо возвращаемое СМЭВ 3</para>
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
