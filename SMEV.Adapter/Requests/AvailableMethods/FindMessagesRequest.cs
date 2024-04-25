using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.FindMethod;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    /// Используйте этот метод для поиска сообщений по критериям. В случае успеха возвращается <see cref="QueryResult"/>
    /// </summary>
    public class FindMessagesRequest : RequestBase<QueryResult>
    {
        /// <summary>
        /// Контейнер вариантов запроса сообщений
        /// </summary>
        [JsonProperty("specificQuery")]
        public SpecificQuery SpecificQuery { get; set; }

        /// <summary>
        /// Инициализация поиска сообщений по идентификатору сообщения
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="requestType">Тип критерия поиска по клиенту</param>
        public FindMessagesRequest(
            string mnemonicIS, 
            string clientId,
            ClientCriteriaRequestType requestType)
            : this(mnemonicIS, new SpecificQuery(clientId, requestType))
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
            string mnemonicIS, 
            DateTimeOffset fromDate, 
            DateTimeOffset toDate, 
            int? countToReturn = null, 
            int? offset = null) 
            : this(
                  mnemonicIS, 
                  new SpecificQuery(
                      fromDate, 
                      toDate, 
                      countToReturn,
                      offset))
        { }

        private FindMessagesRequest(
            string mnemonicIS,
            SpecificQuery specificQuery)
            : this(mnemonicIS)
        {
            SpecificQuery = specificQuery;
        }

        private FindMessagesRequest(string mnemonicIS)
            : base("find", mnemonicIS)
        { }
    }
}
