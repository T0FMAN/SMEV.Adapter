using Newtonsoft.Json;

namespace SMEV.Adapter.Types.FindMethod
{
    /// <summary>
    /// Репрезентация метаданных сообщения
    /// </summary>
    public sealed class SmevMetadata
    {
        private DateTime? _sendingDate = null;

        private const string mask = "yyyy-mm-dd'T'HH:mm:ss.ff'Z'";

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        /// <param name="sendingDate"></param>
        [JsonConstructor]
        public SmevMetadata(DateTime sendingDate)
        {
            if (sendingDate != default)
                _sendingDate = sendingDate;
        }

        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        [JsonProperty("messageId")]
        public string? MessageId { get; set; }
        /// <summary>
        /// Идентификатор транзакции
        /// </summary>
        [JsonProperty("transactionCode")]
        public string? TransactionCode { get; set; }
        /// <summary>
        /// Идентификатор оригинального сообщения
        /// </summary>
        [JsonProperty("originalMessageId")]
        public string? OriginalMessageId { get; set; }
        /// <summary>
        /// Отправитель сообщения
        /// </summary>
        [JsonProperty("sender")]
        public string? Sender { get; set; }
        /// <summary>
        /// Получатель сообщения
        /// </summary>
        [JsonProperty("recipient")]
        public string? Recipient { get; set; }
        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        [JsonProperty("sendingDate")]
        public string? SendingDate
        {
            get
            {
                if (_sendingDate is not null)
                    return _sendingDate.Value.ToString(mask);
                else return default;
            }
        }
    }
}
