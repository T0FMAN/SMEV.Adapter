using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Requests.Abstractions;
using System.Text;

namespace SMEV.Adapter.Requests
{
    /// <summary>
    /// Представление запроса к API.
    /// </summary>
    /// <typeparam name="TResponse">Тип результата, ожидаемого в теле ответа.</typeparam>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        /// <inheritdoc/>
        [JsonProperty("itSystem")] 
        public string? MnemonicIS { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public HttpMethod Method { get; }

        /// <inheritdoc />
        [JsonIgnore]
        public string MethodName { get; }

        /// <summary>
        /// Инициализация экземпляра запроса.
        /// </summary>
        /// <param name="methodName">Метод API.</param>
        /// <param name="mnemonicIS">Мнемоника ИС.</param>
        protected RequestBase(string methodName, string? mnemonicIS = default)
            : this(methodName, mnemonicIS, HttpMethod.Post)
        { }

        /// <summary>
        /// Инициализация экземпляра запроса.
        /// </summary>
        /// <param name="methodName">Метод API.</param>
        /// <param name="mnemonicIS">Мнемоника ИС.</param>
        /// <param name="method">HTTP-метод для исполования.</param>
        protected RequestBase(
            string methodName, 
            string? mnemonicIS, 
            HttpMethod method) =>
            (MethodName, Method, MnemonicIS) = (methodName, method, mnemonicIS);

        /// <inheritdoc/>
        public virtual HttpContent? ToHttpContent() =>
            new StringContent(
                content: JsonConvert.SerializeObject(this),
                encoding: Encoding.UTF8,
                mediaType: "application/json"
            );
    }
}
