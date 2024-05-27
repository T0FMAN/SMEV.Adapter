using SMEV.Adapter.Exceptions;
using SMEV.Adapter.Extensions;
using SMEV.Adapter.Requests.Abstractions;
using System.Runtime.CompilerServices;

namespace SMEV.Adapter
{
    /// <summary>
    /// Клиент для использования адаптера СМЭВ
    /// </summary>
    public class SmevClient : ISmevClient
    {
        /// <inheritdoc/>
        public bool TestEnv { get; set; }

        private readonly SmevClientOptions _options;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Инициализация нового экземпляра <see cref="SmevClient"/>
        /// </summary>
        /// <param name="options">Экземпляр конфигурации</param>
        /// <param name="httpClient">Экземпляр HttpClient</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SmevClient(
            SmevClientOptions options, 
            HttpClient? httpClient = default)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _httpClient = httpClient ?? new HttpClient();
            TestEnv = options.TestEnv;
        }

        /// <summary>
        /// Инициализация нового экземпляра <see cref="SmevClient"/>
        /// </summary>
        /// <param name="baseAddress">Адрес веб-сервиса адаптера</param>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="isSingleIS">Одна ли информационная система, от которой будут исходить запросы</param>
        /// <param name="httpClient">Экземпляр HttpClient</param>
        public SmevClient(
            string baseAddress, 
            string mnemonicIS, 
            bool isSingleIS = true,
            HttpClient? httpClient = null) : 
            this(
                options: new SmevClientOptions(
                    baseAddress, 
                    mnemonicIS, isSingleIS), 
                httpClient)
        { }

        /// <inheritdoc/>
        public async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (_options.SingleSystem)
                request.MnemonicIS = _options.ItSystem;
            else
                request.MnemonicIS.ThrowIfNull();

            var url = $"{_options.BaseAddress}/{request.MethodName}";

            var httpRequest = new HttpRequestMessage(
                method: request.Method, 
                requestUri: url)
            {
                Content = request.ToHttpContent()
            };

            using var httpResponse = await SendRequestAsync(
                httpClient: _httpClient,
                httpRequest: httpRequest,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new NotImplementedException();
            }

            var apiResponse = await httpResponse
                .DeserializeContentAsync<TResponse>()
                .ConfigureAwait(false);

            return apiResponse;

            [MethodImpl(methodImplOptions: MethodImplOptions.AggressiveInlining)]
            static async Task<HttpResponseMessage> SendRequestAsync(
                HttpClient httpClient,
                HttpRequestMessage httpRequest,
                CancellationToken cancellationToken)
            {
                HttpResponseMessage? httpResponse;

                try
                {
                    httpResponse = await httpClient
                        .SendAsync(request: httpRequest, cancellationToken: cancellationToken)
                        .ConfigureAwait(continueOnCapturedContext: false);
                }
                catch (TaskCanceledException exception)
                {
                    if (cancellationToken.IsCancellationRequested)
                        throw;

                    throw new RequestException(
                        message: "Время запроса вышло", 
                        innerException: exception);
                }
                catch (Exception exception)
                {
                    throw new RequestException(
                        message: "Исключение при отправке запроса",
                        innerException: exception);
                }

                return httpResponse;
            }
        }
    }
}
