namespace SMEV.Adapter
{
    /// <summary>
    /// Класс для конфигурации <see cref="SmevClient"/>
    /// </summary>
    public class SmevClientOptions
    {
        /// <summary>
        /// Адрес веб-сервиса адапатера, включая его контекстный путь. 
        /// Например, <c>http://localhost:7590/ws</c>
        /// </summary>
        public string BaseAddress { get; }
        /// <summary>
        /// Мнемоника ИС, от которой исходит запрос / ответ
        /// </summary>
        public string ItSystem { get; }
        /// <summary>
        /// Указатель того, что будет использоваться одна информационная система
        /// </summary>
        public bool SingleSystem { get; }
        /// <summary>
        /// Указатель использования тестовой среды
        /// </summary>
        public bool TestEnv { get; }

        /// <summary>
        /// Инициализация нового экземпляра
        /// </summary>
        /// <param name="baseAddress">Адрес веб-сервиса адаптера, включая его контекстный путь</param>
        /// <param name="itSystem">Мнемоника ИС, от которой будут исходить запросы и ответы</param>
        /// <param name="singleSystem">Будет ли использована одна информационная система, или запросы будут исходить от нескольких</param>
        /// <param name="testEnv">Использование тестовой среды</param>
        public SmevClientOptions(
            string baseAddress, 
            string itSystem, 
            bool singleSystem = true,
            bool testEnv = true)
        {
            BaseAddress = baseAddress;
            ItSystem = itSystem;
            SingleSystem = singleSystem;
            TestEnv = testEnv;
        }
    }
}
