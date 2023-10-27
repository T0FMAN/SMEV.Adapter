﻿using SMEV.Adapter.Enums;
using SMEV.Adapter.Exceptions;
using SMEV.Adapter.Extensions;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Get;
using SMEV.Adapter.Models.Send;
using SMEV.Adapter.Models.Send.Request;
using SMEV.Adapter.Models.Send.Response;
using System.Runtime.CompilerServices;

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

        #region Find method
        /// <inheritdoc />
        public async Task<QueryResult> Find(FindModel findModel)
        {
            var queryResult = new QueryResult();

            if (_options.IsSingleIS)
                findModel.MnemonicIS = _options.MnemonicIS;

            if (findModel.SpecificQuery.MessageClientIdCriteria is not null)
            {
                var isReqByReq = findModel.SpecificQuery.MessageClientIdCriteria.IsReqByReq;
                var isResbyReq = findModel.SpecificQuery.MessageClientIdCriteria.IsResByReq;
                var isResByRes = findModel.SpecificQuery.MessageClientIdCriteria.IsResByRes;

                if (isReqByReq)
                {
                    findModel.SpecificQuery.MessageClientIdCriteria.RequestType = ClientCriteriaRequestType.RequestByRequest;
                    
                    await FindAndConcatResult(findModel);
                }
                if (isResbyReq)
                {
                    findModel.SpecificQuery.MessageClientIdCriteria.RequestType = ClientCriteriaRequestType.ResponseByRequest;

                    await FindAndConcatResult(findModel);
                }
                if (isResByRes)
                {
                    findModel.SpecificQuery.MessageClientIdCriteria.RequestType = ClientCriteriaRequestType.ResponseByResponse;

                    await FindAndConcatResult(findModel);
                }

                async Task FindAndConcatResult(FindModel findModel)
                {
                    var response = await _httpClient.ExecuteRequestToSmev<QueryResult>(EndpointAdapter.find, findModel) 
                        ?? throw new NullDeserializeResultException();

                    response.FoundMessages.ForEach(queryResult.FoundMessages.Add);
                }
            }

            return queryResult;
        }
        #endregion

        #region Get method
        /// <inheritdoc />
        public async Task<QueryQueueMessage> Get(GetModel getModel)
        {
            var result = await _httpClient.ExecuteRequestToSmev<QueryQueueMessage>(EndpointAdapter.get, getModel);

            return result;
        }
        #endregion

        #region Send method
        /// <inheritdoc />
        public async Task<ResponseSentMessage> Send(SendResponseModel responseModel)
        {
            if (_options.IsSingleIS)
                responseModel.MnemonicIS = _options.MnemonicIS;

            return await SendAsync(responseModel);
        }

        /// <inheritdoc/>
        public async Task<ResponseSentMessage> Send(SendRequestModel requestModel)
        {
            if (_options.IsSingleIS)
                requestModel.MnemonicIS = _options.MnemonicIS;

            return await SendAsync(requestModel);
        }

        private async Task<ResponseSentMessage> SendAsync(object sendedModel)
        {
            var sentMessage = await _httpClient.ExecuteRequestToSmev<ResponseSentMessage>(EndpointAdapter.send, sendedModel);

            return sentMessage ?? throw new NullDeserializeResultException();
        }
        #endregion
    }
}
