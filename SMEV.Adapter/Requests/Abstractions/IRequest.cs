using Newtonsoft.Json;

namespace SMEV.Adapter.Requests.Abstractions
{
    /// <summary>
    /// Представление запроса к API.
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// Мнемоника ИС.
        /// </summary>
        [JsonProperty("itSystem")]
        public string? MnemonicIS { get; set; }

        /// <summary>
        /// HTTP-метод запроса.
        /// </summary>
        HttpMethod Method { get; }

        /// <summary>
        /// Имя метода API.
        /// </summary>
        string MethodName { get; }

        /// <summary>
        /// Создание содержимого (тела) HTTP-сообщения.
        /// </summary>
        /// <returns>Контент HTTP-запроса.</returns>
        HttpContent? ToHttpContent();
    }
}
