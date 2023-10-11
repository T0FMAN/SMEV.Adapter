using SMEV.Adapter.Models.Send;

namespace SMEV.Adapter.AdapterWorkers.MessageExchange
{
    /// <summary>
    /// Интерфейс с набором методов для взаимодействия с веб-сервисом адаптера посредством REST API
    /// </summary>
    public interface IMessageExchange : IDisposable
    {
        /// <summary>
        /// Метод Send (отправка запросов и ответов)
        /// </summary>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<ResponseSendAdapter> Send(string data);
        /// <summary>
        /// Метод Get (получение запроса и очереди)
        /// </summary>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<string> Get(string data);
        /// <summary>
        /// Метод Find (поиск запросов)
        /// </summary>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<string> Find(string data);
    }
}
