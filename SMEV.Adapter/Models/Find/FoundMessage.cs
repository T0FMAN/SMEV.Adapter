using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Репрезентация найденного сообщения
    /// </summary>
    public sealed class FoundMessage<T> where T : class
    {
        /// <summary>
        /// Метадата данных СМЭВ
        /// </summary>
        [JsonProperty("smevMetadata")]
        public SmevMetadata SmevMetadata { get; set; }
        /// <summary>
        /// Данные сообщения
        /// </summary>
        [JsonProperty("message")]
        public T Message { get; set; }
    }
}
