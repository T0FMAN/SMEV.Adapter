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
