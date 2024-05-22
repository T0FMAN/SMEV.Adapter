using System.Net;

namespace SMEV.Adapter.Exceptions
{
    /// <summary>
    /// Представление ошибки запроса.
    /// </summary>
    public class RequestException : Exception
    {
        /// <summary>
        /// <see cref="System.Net.HttpStatusCode"/> полученного ответа.
        /// </summary>
        public HttpStatusCode? HttpStatusCode { get; }

        /// <summary>
        /// Инициализация нового экземпляра <see cref="RequestException"/>.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public RequestException(string message)
            : base(message)
        { }

        /// <summary>
        /// Инициализация нового экземпляра <see cref="RequestException"/>.
        /// </summary>
        /// <param name="message">
        /// Сообщение об ошибке, объясняющее причину возникновения исключения.
        /// </param>
        /// <param name="innerException">
        /// Исключение, которое является причиной текущего исключения, или нулевая ссылка, если не указано внутреннее исключение.
        /// </param>
        public RequestException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Инициализация нового экземпляра <see cref="RequestException"/>.
        /// </summary>
        /// <param name="message">
        /// Сообщение об ошибке, объясняющее причину возникновения исключения.
        /// </param>
        /// <param name="httpStatusCode">
        /// <see cref="System.Net.HttpStatusCode"/> полученного ответа.
        /// </param>
        public RequestException(string message, HttpStatusCode httpStatusCode)
            : base(message) =>
            HttpStatusCode = httpStatusCode;

        /// <summary>
        /// Инициализация нового экземпляра <see cref="RequestException"/>.
        /// </summary>
        /// <param name="message">
        /// Сообщение об ошибке, объясняющее причину возникновения исключения.
        /// </param>
        /// <param name="httpStatusCode">
        /// <see cref="System.Net.HttpStatusCode"/> полученного ответа.
        /// </param>
        /// <param name="innerException">
        /// Исключение, которое является причиной текущего исключения, или нулевая ссылка, если не указано внутреннее исключение.
        /// </param>
        public RequestException(string message, HttpStatusCode httpStatusCode, Exception innerException)
            : base(message, innerException) =>
            HttpStatusCode = httpStatusCode;
    }
}
