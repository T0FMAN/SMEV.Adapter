using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Режим передачи вложения
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransferMethodType
    {
        /// <summary>
        /// <para>В составе сообщения.</para>
        /// </summary>
        [EnumMember(Value = "MTOM")]
        Mtom,

        /// <summary>
        /// <para>Отдельно от сообщения.</para>
        /// </summary>
        [EnumMember(Value = "REFERENCE")]
        Reference
    }
}
