namespace SMEV.Adapter.Requests.Abstractions
{
    /// <summary>
    /// Представление запроса к API.
    /// </summary>
    /// <typeparam name="TResponse">Тип результата, ожидаемого в теле ответа.</typeparam>
    public interface IRequest<TResponse> : IRequest
    { }
}
