using SMEV.Adapter.Exceptions;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Send;
using SMEV.Adapter.Models.Send.Request;
using SMEV.Adapter.Models.Send.Response;

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
        /// <param name="message">
        /// Передаваемая модель сообщения. 
        /// Допустима отправка только <see cref="SendRequestModel"/> или <see cref="SendResponseModel"/></param>
        /// <returns>Ответ адаптера на отправленное сообщение</returns>
        /// <exception cref="InvalidArgumentSendedMessageException"></exception>
        Task<ResponseSentMessage> Send(object message);
        /// <summary>
        /// Метод <c>Get</c> (получение запроса и очереди)
        /// </summary>
        /// <param name="data">Строка параметров для передаваемого контента в формате JSON</param>
        /// <returns></returns>
        Task<string> Get(string data);
        /// <summary>
        /// Метод <c>Find</c> (поиск запросов)
        /// </summary>
        /// <param name="findModel">Модель критериев поиска сообщений</param>
        /// <param name="isSingleMnemonic">Единственная мнемоника ИС</param>
        /// <returns>Найденная очередь сообщений, удовлетворяющая критериям поиска</returns>
        Task<QueryResult> Find(FindModel findModel, bool isSingleMnemonic = true);
    }
}
