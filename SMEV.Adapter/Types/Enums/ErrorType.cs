using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Тип ошибки
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ErrorType
    {
        /// <summary>
        /// <para>Ошибка сервера (СМЭВ 3).</para>
        /// </summary>
        [EnumMember(Value = "SERVER")]
        Server,

        /// <summary>
        /// <para>Ошибка клиента (Адаптера СМЭВ 3).</para>
        /// </summary>
        [EnumMember(Value = "CLIENT")]
        Client,
    }
}
