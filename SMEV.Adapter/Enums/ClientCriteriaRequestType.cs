namespace SMEV.Adapter.Enums
{
    /// <summary>
    /// Перечисление для критерия клиента - тип сообщения, по которому производится поиск других сообщений
    /// </summary>
    public enum ClientCriteriaRequestType
    {
        /// <summary>
        /// Получить запрос по клиентскому идентификатору запроса
        /// </summary>
        RequestByRequest,
        /// <summary>
        /// Получить ответ на запрос по клиентскому идентификатору ответа на запрос
        /// </summary>
        ResponseByResponse,
        /// <summary>
        /// Получить ответ на запрос по клиентскому идентификатору запроса
        /// </summary>
        ResponseByRequest,
    }
}
