using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Код причины отклонения запроса
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RejectCode
    {
        /// <summary>
        /// <para>Отсутствуют права на получение информации (например, в случае, если поставщик проверяет ЭП-СП).</para>
        /// </summary>
        [EnumMember(Value = "ACCESS_DENIED")]
        AccessDenied,

        /// <summary>
        /// <para>Сведения отсутствуют.</para>
        /// </summary>
        [EnumMember(Value = "NO_DATA")]
        NoData,

        /// <summary>
        /// <para>Невозможно определить объект запроса информации.</para>
        /// </summary>
        [EnumMember(Value = "UNKNOWN_REQUEST_DESCRIPTION")]
        UnknownRequestDescription,

        /// <summary>
        /// <para>Ошибка.</para>
        /// </summary>
        [EnumMember(Value = "FAILURE")]
        Failure,
    }
}
