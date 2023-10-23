using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Extensions;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Send;

namespace SMEV.Adapter.Helpers
{
    /// <summary>
    /// Помощник по адаптеру
    /// </summary>
    public static class AdapterHelper
    {
        /// <summary>
        /// Адрес веб-сервиса адапатера, включая его контекстный путь. 
        /// Например, <c>http://localhost:7590/ws</c>
        /// </summary>
        public static string Address = "http://localhost:7590/ws";
        /// <summary>
        /// Мнемоника ИС, от которой исходит запрос / ответ
        /// </summary>
        public static string MnemonicIS;

        internal static async Task<Model> ExecuteRequestToSmev<Model>(this HttpClient httpClient, EndpointAdapter endpoint, object messageData)
        {
            var uri = new Uri(@$"{Address}/{endpoint}");

            var json = JsonConvert.SerializeObject(messageData);

            var response = await httpClient.GetResponse(uri, json);

            object model = endpoint switch
            {
                EndpointAdapter.send => JsonHelper.DeserializeResponseSmev<ResponseSentMessage>(response),
                EndpointAdapter.find => JsonHelper.DeserializeResponseSmev<QueryResult<object>>(response),
                _ => throw new NotImplementedException()
            };

            return (Model)Convert.ChangeType(model, typeof(Model));
        }
    }
}
