using Newtonsoft.Json;

namespace SMEV.Adapter.Types.Find
{
    /// <summary>
    /// Метаданные сообщения
    /// </summary>
    public sealed class SmevMetadata
    {
        /// <summary>
        /// <para>
        /// Идентификатор сообщения (запроса, либо ответа на запрос) в строковом представлении UUID.
        /// Данный идентификатор используется в СМЭВ 3 для процессинга сообщений.
        /// Генерируется адаптером при отправке сообщения в СМЭВ 3 в соответствии с RFC-4122, по варианту 1 (на основании MAC-адреса и текущего времени).
        /// Также идентификатор сообщения приходит в адаптер из СМЭВ 3 вместе с запросом либо ответом на запрос.
        /// Данный элемент заполняется адаптером
        /// </para>
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; } = default!;

        /// <summary>
        /// <para>
        /// Идентификатор корневого запроса (запроса, порождающего цепочку запросов) в строковом представлении UUID.
        /// Соответствует RFC-4122, по варианту 1 (на основании MAC-адреса и текущего времени).
        /// Также данный идентификатор приходит в адаптер из СМЭВ 3 вместе с запросом.
        /// Данный элемент заполняется адаптером
        /// </para>
        /// </summary>
        [JsonProperty("referenceMessageID")]
        public string? ReferenceMessageId { get; set; }

        /// <summary>
        /// <para>
        /// Код транзакции. 
        /// При отправке запроса в СМЭВ 3 адаптер формирует код транзакции самостоятельно.
        /// Также код транзакции приходит в адаптер из СМЭВ 3 вместе с запросом либо ответом на запрос.
        /// Адаптер заполняет данный элемент кодом транзакции, полученным из СМЭВ 3
        /// </para>
        /// </summary>
        [JsonProperty("transactionCode")]
        public string? TransactionCode { get; set; }

        /// <summary>
        /// <para>
        /// Идентификатор запроса, на который пришел ответ, в строковом представлении UUID.
        /// Данный идентификатор используется в СМЭВ 3 для процессинга ответов на запросы.
        /// Соответствует RFC-4122, по варианту 1 (на основании MAC-адреса и текущего времени).
        /// Приходит в адаптер из СМЭВ 3 вместе с ответом на запрос.
        /// Данный элемент заполняется адаптером
        /// </para>
        /// </summary>
        [JsonProperty("originalMessageId")]
        public string? OriginalMessageId { get; set; }

        /// <summary>
        /// <para>Мнемоника системы отправителя</para>
        /// </summary>
        [JsonProperty("sender")]
        public string? Sender { get; set; }

        /// <summary>
        /// <para>Мнемоника системы получателя</para>
        /// </summary>
        [JsonProperty("recipient")]
        public string? Recipient { get; set; }

        /// <summary>
        /// <para>Строка replyTo из оригинального запроса</para>
        /// </summary>
        [JsonProperty("replyTo")]
        public string? ReplyTo { get; set; }

        /// <summary>
        /// <para>Дата и время создания запроса или ответа на запрос</para>
        /// </summary>
        [JsonProperty("sendingDate")]
        public DateTime? SendingDate { get; set; } = default;
    }
}
