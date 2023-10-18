using SMEV.Adapter.Models.Find.ResponseFound;
using SMEV.Adapter.Models.Send;

namespace SMEV.Adapter
{
    /// <summary>
    /// Интерфейс с набором методов для взаимодействия с веб-сервисом адаптера посредством REST API
    /// </summary>
    public interface IMessageExchange : IDisposable
    {
        /// <summary>
        /// Метод <c>Send</c> (отправка запросов и ответов)
        /// </summary>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<ResponseSentMessage> Send(string data);
        /// <summary>
        /// Метод <c>Get</c> (получение запроса и очереди)
        /// </summary>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<string> Get(string data);
        /// <summary>
        /// Метод <c>Find</c> (поиск запросов)
        /// </summary>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<QueryResult> Find(string data);
    }
}
