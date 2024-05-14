using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Тип сообщения для статусной категории
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusMessageCategory
    {
        /// <summary>
        /// <para>Иной статус</para>
        /// </summary>
        [EnumMember(Value = "OTHER")]
        Other,

        /// <summary>
        /// <para>Ошибка</para>
        /// </summary>
        [EnumMember(Value = "ERROR")]
        Error,
    }
}
