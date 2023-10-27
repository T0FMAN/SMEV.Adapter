using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Модель метода <c>Find</c>
    /// </summary>
    public sealed class FindModel
    {
        /// <summary>
        /// Инициализация модели <c>Find</c> с другой мнемоникой, 
        /// отличной от указанной в параметрах при инициализации экземпляра <see cref="MessageExchange"/>
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС (код ИС в ИУА)</param>
        /// <param name="specificQuery">Контейнер c параметрами запроса сообщений</param>
        public FindModel(string mnemonicIS, SpecificQuery specificQuery) 
        {
            MnemonicIS = mnemonicIS;
            SpecificQuery = specificQuery;
        }

        /// <summary>
        /// Инициализация модели <c>Find</c>
        /// </summary>
        /// <param name="specificQuery">Контейнер c параметрами запроса сообщений</param>
        public FindModel(SpecificQuery specificQuery) 
        {
            SpecificQuery = specificQuery;
        }

        /// <summary>
        /// Инициалиазция поиска сообщений по идентификатору сообщения
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="isReqByReq">Включить в поиск сообщения сообщение-запрос на запрос</param>
        /// <param name="isResByRes">Включить в поиск сообщения сообщение-ответ на ответ</param>
        /// <param name="isResByReq">Включить в поиск сообщения сообщение-ответ на запрос</param>
        public FindModel(string clientId, bool isReqByReq = true, bool isResByRes = true, bool isResByReq = true):
            this(new SpecificQuery(clientId, isReqByReq, isResByRes, isResByReq))
        { }

        /// <summary>
        /// Инициалиазция поиска сообщений по идентификатору сообщения с отличной мнемоникой ИС (для систем с несколькими мнемониками)
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="isReqByReq">Включить в поиск сообщения сообщение-запрос на запрос</param>
        /// <param name="isResByRes">Включить в поиск сообщения сообщение-ответ на ответ</param>
        /// <param name="isResByReq">Включить в поиск сообщения сообщение-ответ на запрос</param>
        public FindModel(string mnemonicIS, string clientId, bool isReqByReq = true, bool isResByRes = true, bool isResByReq = true) :
            this(mnemonicIS, new SpecificQuery(clientId, isReqByReq, isResByRes, isResByReq))
        { }

        /// <summary>
        /// Инициалиазция поиска сообщений по временному диапазону
        /// </summary>
        /// <param name="fromDate">Дата и время от которой нужно начать поиск</param>
        /// <param name="toDate">Дата и время до которой нужно начать поиск</param>
        /// <param name="countToReturn">Количество сообщений, которое нужно вернуть (необязательно)</param>
        /// <param name="offset">Смещение сообщения (необязательно)</param>
        public FindModel(DateTimeOffset fromDate, DateTimeOffset toDate, int? countToReturn = null, int? offset = null) :
            this(new SpecificQuery(fromDate, toDate, countToReturn, offset))
        { }

        /// <summary>
        /// Инициалиазция поиска сообщений по временному диапазону с отличной мнемоникой ИС (для систем с несколькими мнемониками)
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС</param>
        /// <param name="fromDate">Дата и время от которой нужно начать поиск</param>
        /// <param name="toDate">Дата и время до которой нужно начать поиск</param>
        /// <param name="countToReturn">Количество сообщений, которое нужно вернуть (необязательно)</param>
        /// <param name="offset">Смещение сообщения (необязательно)</param>
        public FindModel(string mnemonicIS, DateTimeOffset fromDate, DateTimeOffset toDate, int? countToReturn = null, int? offset = null) :
            this(mnemonicIS, new SpecificQuery(fromDate, toDate, countToReturn, offset))
        { }

        /// <summary>
        /// Мнемоника ИС (код ИС в ИУА)
        /// </summary>
        [JsonProperty("itSystem")]
        public string MnemonicIS { get; set; } = default!;
        /// <summary>
        /// Контейнер вариантов запроса сообщений
        /// </summary>
        [JsonProperty("specificQuery")]
        public SpecificQuery SpecificQuery { get; set; } = default!;
    }
}
