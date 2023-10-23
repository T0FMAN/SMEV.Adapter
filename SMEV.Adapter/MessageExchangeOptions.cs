namespace SMEV.Adapter
{
    /// <summary>
    /// Класс для конфигурации <see cref="MessageExchange"/>
    /// </summary>
    public class MessageExchangeOptions
    {
        /// <summary>
        /// Адрес веб-сервиса адапатера, включая его контекстный путь. 
        /// Например, <c>http://localhost:7590/ws</c>
        /// </summary>
        public string BaseAddress { get; }
        /// <summary>
        /// Мнемоника ИС, от которой исходит запрос / ответ
        /// </summary>
        public string MnemonicIS { get; }

        /// <summary>
        /// Инициализация нового экземпляра
        /// </summary>
        /// <param name="baseAddress">Адрес веб-сервиса адаптера, включая его контекстный путь</param>
        /// <param name="mnemonicIS">Мнемоника ИС, от которой будут исходить запросы и ответы</param>
        public MessageExchangeOptions(string baseAddress, string mnemonicIS)
        {
            BaseAddress = baseAddress;
            MnemonicIS = mnemonicIS;
        }
    }
}
