using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Тип сообщения для поиска в очереди сообщения
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageFindType
    {
        /// <summary>
        /// Запрос
        /// </summary>
        [EnumMember(Value = "REQUEST")]
        Request,
        /// <summary>
        /// Ответ
        /// </summary>
        [EnumMember(Value = "RESPONSE")]
        Response
    }
}
