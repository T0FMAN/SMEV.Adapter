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
        /// Запрос
        /// </summary>
        RequestMessageType,
        /// <summary>
        /// Ответ
        /// </summary>
        ResponseMessageType,
        /// <summary>
        /// Ошибка
        /// </summary>
        ErrorMessageType,
        /// <summary>
        /// Статус
        /// </summary>
        StatusMessageType
    }
}
