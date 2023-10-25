using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send.Response
{
    /// <summary>
    /// Модель отправляемого сообщения-ответа
    /// </summary>
    public sealed class SendResponseModel
    {
        /// <summary>
        /// Инициализация отправляемого сообщения с мнемоникой ИС, 
        /// отличной от стандартной, указанной при инициализации <see cref="MessageExchange"/>
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС, от лица которой будет отправлено сообщение</param>
        /// <param name="message">Сообщение-ответ</param>
        public SendResponseModel(string mnemonicIS, ResponseMessage message) 
        {
            MnemonicIS = mnemonicIS;
            Message = message;
        }

        /// <summary>
        /// Инициализация отправляемого сообщения
        /// </summary>
        /// <param name="message">Сообщение-ответ</param>
        public SendResponseModel(ResponseMessage message) 
        {
            Message = message;
        }

        /// <summary>
        /// Мнемоника ИС
        /// </summary>
        [JsonProperty("itSystem")]
        public string MnemonicIS { get; set; } = default!;
        /// <summary>
        /// Сообщение-запрос
        /// </summary>
        [JsonProperty("responseMessage")]
        public ResponseMessage Message { get; set; } = default!;
    }
}
