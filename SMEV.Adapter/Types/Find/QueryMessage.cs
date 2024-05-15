using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Сообщение запроса
    /// </summary>
    public class QueryMessage : Message
    {
        /// <summary>
        /// <para>
        /// Клиентский идентификатор сообщения (запроса либо ответа на запрос) в виде уникальной произвольной последовательности цифр и/или латинских букв.
        /// Данный элемент заполняется ИС УВ при отправке сообщения (запроса либо ответа на запрос) в адаптер.
        /// При получении ИС УВ сообщения (запроса либо ответа на запрос) из адаптера данный элемент заполняется адаптером.</para>
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; } = default!;

        /// <summary>
        /// <para>Идентификатор нода (узла) отправителя запроса</para>
        /// </summary>
        [JsonProperty("nodeId")]
        public string? NodeId { get; set; }

        /// <summary>
        /// <para>Тип запроса</para>
        /// </summary>
        [JsonProperty("queryType")]
        public MessageFindType QueryType { get; set; }

        /// <summary>
        /// <para>Фильтр</para>
        /// </summary>
        [JsonProperty("queryFilter")]
        public string? QueryFilter { get; set; }

        /// <summary>
        /// <para>Корневой тег фильтра</para>
        /// </summary>
        [JsonProperty("queryRootTag")]
        public string? QueryRootTag { get; set; }
    }
}
