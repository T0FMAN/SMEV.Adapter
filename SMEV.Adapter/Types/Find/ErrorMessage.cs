using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Сообщение ошибки
    /// </summary>
    public class ErrorMessage : StatusMessage
    {
        /// <summary>
        /// <para>Тип источника ошибки.</para>
        /// </summary>
        [JsonProperty("type")]
        public ErrorType Type { get; set; }

        /// <summary>
        /// <para>Сведения об ошибке.</para>
        /// </summary>
        [JsonProperty("fault")]
        public Fault Fault { get; set; } = default!;
    }
}
