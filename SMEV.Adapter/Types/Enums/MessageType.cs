namespace SMEV.Adapter.Types.Enums
{
    /// <summary>
    /// Перечисление типов сообщения
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Тип сообщения - запрос
        /// </summary>
        RequestMessageType,
        /// <summary>
        /// Тип сообщения - ответ
        /// </summary>
        ResponseMessageType,
        /// <summary>
        /// Индикация об сообщении с ошибкой - используется только для десериализации!
        /// </summary>
        ErrorMessage
    }
}
