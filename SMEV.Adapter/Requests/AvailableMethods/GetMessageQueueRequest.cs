using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types.FindMethod;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    /// Используйте этот метод для получения очереди и запроса. В случае успеха возвращается <see cref="QueryQueueMessage"/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetMessageQueueRequest : RequestBase<FoundMessage>
    {
        /// <summary>
        /// Инициализация нового запроса получения очереди и запроса
        /// </summary>
        public GetMessageQueueRequest(string? mnemonicIS = default)
            : base("get", mnemonicIS)
        { }
    }
}
