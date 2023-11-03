using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Get;
using SMEV.Adapter.Models.Send;
using System.ComponentModel;

namespace SMEV.Adapter.Extensions
{
    internal static class AdapterExtensions
    {
        internal static async Task<Model> ExecuteRequestToSmev<Model>(this HttpClient httpClient, EndpointAdapter endpoint, object messageModel)
        {
            var uri = new Uri(@$"{httpClient.BaseAddress}/{endpoint}");

            var messageData = JsonConvert.SerializeObject(messageModel);

            var response = await httpClient.GetResponse(uri, messageData);

            object model = endpoint switch
            {
                EndpointAdapter.send => response.DeserializeSmevResponse<ResponseSentMessage>(),
                EndpointAdapter.find => response.DeserializeSmevResponse<QueryResult>(),
                EndpointAdapter.get => response.DeserializeSmevResponse<QueryQueueMessage>(),
                _ => throw new InvalidEnumArgumentException(nameof(endpoint)),
            };

            return (Model)Convert.ChangeType(model, typeof(Model));
        }
    }
}
