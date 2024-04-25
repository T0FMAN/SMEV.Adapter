using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types.GetMethod;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    /// Используйте этот метод для получения очереди и запроса. В случае успеха возвращается <see cref=""/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetMessageQueueRequest : RequestBase<QueryQueueMessage>
    {
        /// <summary>
        /// Инициализация нового запроса получения очереди и запроса
        /// </summary>
        public GetMessageQueueRequest()
            : base("get")
        { }
    }
}
