using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Класс модели для метода <c>Find</c>
    /// </summary>
    public sealed class FindModel
    {
        /// <summary>
        /// Инициализация класса модели <c>Find</c>
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС (код ИС в ИУА)</param>
        /// <param name="specificQuery">Контейнер, включает варианты запроса сообщений</param>
        public FindModel(string mnemonicIS, SpecificQuery specificQuery) 
        {
            ItSystem = mnemonicIS;
            SpecificQuery = specificQuery;
        }

        /// <summary>
        /// Мнемоника ИС (код ИС в ИУА)
        /// </summary>
        [JsonProperty("itSystem")]
        public string ItSystem { get; set; }
        /// <summary>
        /// Контейнер, включает варианты запроса сообщений
        /// </summary>
        [JsonProperty("specificQuery")]
        public SpecificQuery SpecificQuery { get; set; }
    }
}
