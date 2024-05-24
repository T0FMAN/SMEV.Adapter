using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Тип сообщения
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        /// <summary>
        /// Сообщение-запрос
        /// </summary>
        RequestMessageType,
        /// <summary>
        /// Сообщение-ответ
        /// </summary>
        ResponseMessageType,
        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        ErrorMessage,
        /// <summary>
        /// Статусное сообщение
        /// </summary>
        StatusMessageType,
        /// <summary>
        /// Сообщение запроса (не RequestMessageType)
        /// </summary>
        QueryMessageType
    }
}
