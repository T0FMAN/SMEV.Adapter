using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Helpers;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Send;

namespace SMEV.Adapter.Extensions
{
    internal static class AdapterExtensions
    {
        internal static async Task<Model> ExecuteRequestToSmev<Model>(this HttpClient httpClient, EndpointAdapter endpoint, object messageData)
        {
            var uri = new Uri(@$"{httpClient.BaseAddress}/{endpoint}");

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
