using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Requests.Abstractions;
using System.Text;

namespace SMEV.Adapter.Requests
{
    /// <summary>
    /// Represents an API request
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result</typeparam>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        /// <inheritdoc/>
        [JsonProperty("itSystem")]
        public string MnemonicIS { get; }

        /// <inheritdoc />
        [JsonIgnore]
        public HttpMethod Method { get; }

        /// <inheritdoc />
        [JsonIgnore]
        public string MethodName { get; }

        /// <summary>
        /// Initializes an instance of request
        /// </summary>
        /// <param name="methodName">API method</param>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        protected RequestBase(string methodName, string mnemonicIS)
            : this(methodName, mnemonicIS, HttpMethod.Post)
        { }

        /// <summary>
        /// Initializes an instance of request
        /// </summary>
        /// <param name="methodName">API method</param>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="method">HTTP method to use</param>
        protected RequestBase(
            string methodName, 
            string mnemonicIS, 
            HttpMethod method) =>
            (MethodName, Method, MnemonicIS) = (methodName, method, mnemonicIS);

        /// <summary>
        /// Generate content of HTTP message
        /// </summary>
        /// <returns>Content of HTTP request</returns>
        public virtual HttpContent? ToHttpContent() =>
            new StringContent(
                content: JsonConvert.SerializeObject(this),
                encoding: Encoding.UTF8,
                mediaType: "application/json"
            );
    }
}
