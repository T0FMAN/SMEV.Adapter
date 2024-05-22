using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Перечисление для критерия клиента - тип сообщения, по которому производится поиск других сообщений
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClientCriteriaRequestType
    {
        /// <summary>
        /// Получить запрос по клиентскому идентификатору запроса
        /// </summary>
        [EnumMember(Value = "GET_REQUEST_BY_REQUEST_CLIENTID")]
        RequestByRequest,
        /// <summary>
        /// Получить ответ на запрос по клиентскому идентификатору ответа на запрос
        /// </summary>
        [EnumMember(Value = "GET_RESPONSE_BY_RESPONSE_CLIENTID")]
        ResponseByResponse,
        /// <summary>
        /// Получить ответ на запрос по клиентскому идентификатору запроса
        /// </summary>
        [EnumMember(Value = "GET_RESPONSE_BY_REQUEST_CLIENTID")]
        ResponseByRequest,
    }
}
