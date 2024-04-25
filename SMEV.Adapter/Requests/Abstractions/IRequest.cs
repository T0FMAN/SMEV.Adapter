namespace SMEV.Adapter.Requests.Abstractions
{
    /// <summary>
    /// Represents a request to API
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// HTTP method of request
        /// </summary>
        HttpMethod Method { get; }

        /// <summary>
        /// API method name
        /// </summary>
        string MethodName { get; }

        /// <summary>
        /// Generate content of HTTP message
        /// </summary>
        /// <returns>Content of HTTP request</returns>
        HttpContent? ToHttpContent();
    }
}
