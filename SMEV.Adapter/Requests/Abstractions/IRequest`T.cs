namespace SMEV.Adapter.Requests.Abstractions
{
    /// <summary>
    /// Represents a request to API
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result</typeparam>
    public interface IRequest<TResponse> : IRequest
    { }
}
