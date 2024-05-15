using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.Find;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    /// Используйте этот метод для получения сообщения из очереди. В случае успеха возвращается <see cref="AdapterMessage"/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetMessageQueueRequest : RequestBase<AdapterMessage>
    {
        /// <summary>
        /// Код определенного узла ИС в ИУА
        /// </summary>
        [JsonProperty("nodeId")]
        public string? NodeId { get; set; } = default!;

        /// <summary>
        /// Наименование очереди для получения ответа на запрос
        /// </summary>
        [JsonProperty("routerExtraQueue")]
        public string? Queue { get; set; } = default!;

        /// <summary>
        /// Тип сообщения для поиска
        /// </summary>
        [JsonProperty("messageTypeCriteria")]
        public MessageFindType? FindType { get; set; }

        /// <summary>
        /// Инициализация нового запроса получения сообщения из очереди
        /// </summary>
        public GetMessageQueueRequest(
            string? mnemonicIS = default,
            string? nodeId = default,
            string? queue = default,
            MessageFindType? findType = null)
            : base("get", mnemonicIS)
        {
            NodeId = nodeId;
            Queue = queue;
            FindType = findType;
        }
    }
}
