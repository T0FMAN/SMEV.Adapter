using SMEV.Adapter.Enums;
using SMEV.Adapter.Exceptions;
using SMEV.Adapter.Extensions;
using SMEV.Adapter.Models;
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
        private readonly MessageExchangeOptions _options;

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Инициализация нового экземпляра <see cref="MessageExchange"/>
        /// </summary>
        /// <param name="options">Экземпляр конфигурации</param>
        /// <param name="httpClient">Экземпляр HttpClient</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MessageExchange(
            MessageExchangeOptions options, 
            HttpClient? httpClient = default)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _httpClient = httpClient ?? new HttpClient() { BaseAddress = new Uri(_options.BaseAddress) };
        }

        /// <summary>
        /// Инициализация нового экземпляра <see cref="MessageExchange"/>
        /// </summary>
        /// <param name="baseAddress">Адрес веб-сервиса адаптера</param>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="isSingleIS">Одна ли информационная система, от которой будут исходить запросы</param>
        /// <param name="httpClient">Экземпляр HttpClient</param>
        public MessageExchange(
            string baseAddress, 
            string mnemonicIS, 
            bool isSingleIS = true,
            HttpClient? httpClient = null) : 
            this(new MessageExchangeOptions(baseAddress, mnemonicIS, isSingleIS), httpClient)
        { }

        /// <inheritdoc />
        public void Dispose() => _httpClient.Dispose();

        /// <inheritdoc />
        public async Task<QueryResult> Find(FindModel findModel)
        {
            if (_options.IsSingleIS)
                findModel.MnemonicIS = _options.MnemonicIS;

            var queryResult = await _httpClient.ExecuteRequestToSmev<QueryResult>(EndpointAdapter.find, findModel);
            
            return queryResult ?? throw new NullDeserializeResultException();
        }

        /// <inheritdoc />
        public async Task<string> Get(string data)
        {
            var result = await _httpClient.ExecuteRequestToSmev<string>(EndpointAdapter.get, data);

            return result;
        }

        /// <inheritdoc />
        public async Task<ResponseSentMessage> Send(object message)
        {
            if (message is not SendRequestModel or SendResponseModel)
                throw new InvalidArgumentSendedMessageException();

            var messageBody = message;

            if (_options.IsSingleIS)
                messageBody = message.SetModelMnemonicIS(_options.MnemonicIS);

            var sentMessage = await _httpClient.ExecuteRequestToSmev<ResponseSentMessage>(EndpointAdapter.send, messageBody);

            return sentMessage ?? throw new NullDeserializeResultException();
        }
    }
}
