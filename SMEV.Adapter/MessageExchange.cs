using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Exceptions;
using SMEV.Adapter.Extensions;
using SMEV.Adapter.Helpers;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Send;
using SMEV.Adapter.Models.Send.Request;
using SMEV.Adapter.Models.Send.Response;

namespace SMEV.Adapter
{
    /// <summary>
    /// Класс реализации интерфейса <see cref="IMessageExchange"/>
    /// </summary>
    public sealed class MessageExchange : IMessageExchange
    {
        private readonly HttpClient _httpClient;
        private readonly string Address;

        /// <summary>
        /// Конструктор для инициализации параметров
        /// </summary>
        /// <param name="address">Адрес веб-сервиса адапатера, включая его контекстный путь. 
        /// Например, 'http://localhost:7590/ws'</param>
        public MessageExchange(string address) // Убрать 'address' после реализации статического конструктора
        {
            _httpClient = new HttpClient();
            Address = address;
        }

        static MessageExchange()
        {
            // Добавить инициализацию статических параметров (адрес, мнемоника ИС и тд) из JSON
        }

        /// <inheritdoc />
        public void Dispose() => _httpClient.Dispose();

        /// <inheritdoc />
        public async Task<QueryResult<object>> Find(FindModel findModel)
        {
            var queryResult = await _httpClient.ExecuteRequestToSmev<QueryResult<object>>(EndpointAdapter.find, findModel);

            return queryResult ?? throw new NullDeserializeResultException();
        }

        /// <inheritdoc />
        public async Task<string> Get(string data)
        {
            var uri = new Uri(@$"{Address}/get");

            return await _httpClient.GetResponse(uri, data);
        }

        /// <inheritdoc />
        public async Task<ResponseSentMessage> Send(object message)
        {
            if (message is not SendRequestModel or SendResponseModel)
                throw new InvalidArgumentSendedMessageException();

            var sentMessage = await _httpClient.ExecuteRequestToSmev<ResponseSentMessage>(EndpointAdapter.send, message);

            return sentMessage ?? throw new NullDeserializeResultException();
        }
    }
}
