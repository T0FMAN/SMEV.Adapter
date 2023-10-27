using SMEV.Adapter.Exceptions;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Get;
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
        /// Метод <c>Send</c> (отправка запроса)
        /// </summary>
        /// <param name="requestModel">Модель отправляемого сообщения</param>
        /// <returns>Ответ адаптера на отправленное сообщение</returns>
        /// <exception cref="NullDeserializeResultException"></exception>
        Task<ResponseSentMessage> Send(SendRequestModel requestModel);
        /// <summary>
        /// Метод <c>Send</c> (отправка ответа)
        /// </summary>
        /// <param name="responseModel">Модель отправляемого сообщения</param>
        /// <returns>Ответ адаптера на отправленное сообщение</returns>
        /// <exception cref="NullDeserializeResultException"></exception>
        Task<ResponseSentMessage> Send(SendResponseModel responseModel);
        /// <summary>
        /// Метод <c>Get</c> (получение запроса и очереди)
        /// </summary>
        /// <param name="getModel">Модель получения очереди сообщений</param>
        /// <returns>Очередь сообщений</returns>
        Task<QueryQueueMessage> Get(GetModel getModel);
        /// <summary>
        /// Метод <c>Find</c> (поиск запросов)
        /// </summary>
        /// <param name="findModel">Модель критериев поиска сообщений</param>
        /// <returns>Найденная очередь сообщений, удовлетворяющая критериям поиска</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullDeserializeResultException"></exception>
        Task<QueryResult> Find(FindModel findModel);
    }
}
