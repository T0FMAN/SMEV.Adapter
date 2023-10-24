namespace SMEV.Adapter.Models.MessageMetadata
{
    /// <summary>
    /// Репрезентация блока метаданных сообщения
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Уникальный идентификатор запроса
        /// </summary>
        public string ClientId { get; set; } = default!;
        /// <summary>
        /// Ссылочная группа
        /// </summary>
        public LinkedGroupIdentity? LinkedGroupIdentity { get; set; }
        /// <summary>
        /// Тестовое сообщение
        /// </summary>
        public bool? TestMessage { get; set; }
        /// <summary>
        /// Код транзакции
        /// </summary>
        public string? TransactionCode { get; set; }
        /// <summary>
        /// Уникальный идентификатор сообщения, на которое был дан ответ данного сообщения
        /// </summary>
        public string? ReplyToClientId { get; set; }
    }
}
