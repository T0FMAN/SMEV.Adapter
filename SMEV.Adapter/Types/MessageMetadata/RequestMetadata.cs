using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageMetadata
{
    /// <summary>
    /// Метаданные сообщения запроса
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RequestMetadata : Metadata
    {
        /// <summary>
        /// <para>
        /// Необходим для привязывания запроса к последовательности запросов
        /// либо привязывания новой последовательности запросов к группе последовательностей запросов
        /// </para>
        /// </summary>
        [JsonProperty("linkedGroupIdentity")]
        public LinkedGroupIdentity? LinkedGroupIdentity { get; set; }

        /// <summary>
        /// <para>
        /// Необходим для формирования Адаптером СМЭВ кода транзакции в случаях,
        /// если <see cref="MessageMetadata.LinkedGroupIdentity"/> не передаются вместе с запросом
        /// </para>
        /// </summary>
        [JsonProperty("createGroupIdentity")]
        public CreateGroupIdentity? CreateGroupIdentity { get; set; }

        /// <summary>
        /// <para>Идентификатор нода (узла) отправителя запроса</para>
        /// </summary>
        [JsonProperty("nodeId")]
        public string? NodeId { get; set; }

        /// <summary>
        /// <para>Ограничение времени жизни запроса</para>
        /// </summary>
        [JsonProperty("eol")]
        public DateTime? Eol { get; set; }

        /// <summary>
        /// <para>Флаг, указывающий на тестовое сообщение</para>
        /// </summary>
        [JsonProperty("testMessage")]
        public bool? TestMessage { get; set; }

        /// <summary>
        /// <para>Код транзакции, заполняемый ИС УВ из исходного запроса (возможно даже другого ВС)</para>
        /// </summary>
        [JsonProperty("transactionCode")]
        public string? TransactionCode { get; set; }

        /// <summary>
        /// Информация о бизнес-процессе, в рамках которого пересылается сообщение
        /// </summary>
        [JsonProperty("businessProcessMetadata")]
        public object? BusinessProcessMetadata { get; set; }

        /// <summary>
        /// Информация о маршрутизации
        /// </summary>
        [JsonProperty("routingInformation")]
        public object? RoutingInformation { get; set; }
    }
}
