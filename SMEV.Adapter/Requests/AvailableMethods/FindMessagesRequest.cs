using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.Find;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    /// Используйте этот метод для поиска сообщений по критериям. В случае успеха возвращается <see cref="QueryResult"/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class FindMessagesRequest : RequestBase<QueryResultList>
    {
        /// <summary>
        /// Контейнер вариантов запроса сообщений
        /// </summary>
        [JsonProperty("specificQuery")]
        public SpecificQuery SpecificQuery { get; set; } = default!;

        /// <summary>
        /// Инициализация поиска сообщений по идентификатору сообщения
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="requestType">Тип критерия поиска по клиенту</param>
        public FindMessagesRequest(
            string clientId,
            ClientCriteriaRequestType requestType,
            string? mnemonicIS = default)
            : this(new SpecificQuery(clientId, requestType), mnemonicIS)
        { }

        /// <summary>
        /// Инициализация поиска сообщений по временному диапазону
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="fromDate">Дата и время от которой нужно начать поиск</param>
        /// <param name="toDate">Дата и время до которой нужно начать поиск</param>
        /// <param name="countToReturn">Количество сообщений, которое нужно вернуть (необязательно)</param>
        /// <param name="offset">Смещение сообщения (необязательно)</param>
        public FindMessagesRequest(
            DateTimeOffset fromDate, 
            DateTimeOffset? toDate = default, 
            int? countToReturn = default, 
            int? offset = default,
            string? mnemonicIS = default) 
            : this(
                  new SpecificQuery(
                      fromDate, 
                      toDate, 
                      countToReturn,
                      offset),
                  mnemonicIS)
        { }

        private FindMessagesRequest(
            SpecificQuery specificQuery,
            string? mnemonicIS = default)
            : this(mnemonicIS)
        {
            SpecificQuery = specificQuery;
        }

        private FindMessagesRequest(string? mnemonicIS = default)
            : base("find", mnemonicIS)
        { }
    }
}
