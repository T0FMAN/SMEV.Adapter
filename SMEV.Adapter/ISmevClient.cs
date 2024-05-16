using SMEV.Adapter.Requests.Abstractions;

namespace SMEV.Adapter
{
    /// <summary>
    /// Интерфейс клиента для использования адапатера СМЭВ.
    /// </summary>
    public interface ISmevClient
    {
        /// <summary>
        /// <para>Указатель использования тестовой среды.</para>
        /// <para>Если указано <see langword="true"></see>, 
        /// сообщение помечается как тестовое и отправляется в эмулятор.</para>
        /// </summary>
        bool TestEnv { get; set; }

        /// <summary>
        /// Отправка запроса к API.
        /// </summary>
        /// <typeparam name="TResponse">Тип ожидаемого результата в объекте ответа.</typeparam>
        /// <param name="request">Объект запроса API.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат запроса API.</returns>
        Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default
        );
    }
}
