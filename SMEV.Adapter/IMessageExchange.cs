namespace SMEV.Adapter
{
    /// <summary>
    /// Интерфейс с набором методов для взаимодействия с веб-сервисом адаптера посредством REST API
    /// </summary>
    public interface IMessageExchange : IDisposable
    {
        /// <summary>
        /// Метод Send (отправка запросов и ответов)
        /// </summary>
        /// <param name="address">Адрес веб-сервиса адаптера, включая его контекстный путь</param>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<string> Send(string address, string data);
        /// <summary>
        /// Метод Get (получение запроса и очереди)
        /// </summary>
        /// <param name="address">Адрес веб-сервиса адаптера, включая его контекстный путь</param>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<string> Get(string address, string data);
        /// <summary>
        /// Метод Find (поиск запросов)
        /// </summary>
        /// <param name="address">Адрес веб-сервиса адаптера, включая его контекстный путь</param>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<string> Find(string address, string data);
    }
}
