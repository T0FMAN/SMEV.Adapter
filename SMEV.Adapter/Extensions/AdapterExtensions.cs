using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Helpers;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Send;
using SMEV.Adapter.Models.Send.Request;
using SMEV.Adapter.Models.Send.Response;
using System.ComponentModel;

namespace SMEV.Adapter.Extensions
{
    internal static class AdapterExtensions
    {
        internal static object SetModelMnemonicIS(this object model, string mnemonicIS)
        {
            if (model is SendRequestModel)
            {
                var sendRequestModel = (SendRequestModel)model;

                sendRequestModel.MnemonicIS = mnemonicIS;

                return sendRequestModel;
            }
            else if (model is SendResponseModel)
            {
                var sendResponseModel = (SendResponseModel)model;

                sendResponseModel.MnemonicIS = mnemonicIS;

                return sendResponseModel;
            }
            else throw new TypeInitializationException(nameof(model), new Exception("Type not supported"));
        }

        internal static async Task<Model> ExecuteRequestToSmev<Model>(this HttpClient httpClient, EndpointAdapter endpoint, object messageBody)
        {
            var uri = new Uri(@$"{httpClient.BaseAddress}/{endpoint}");

            var messageData = JsonConvert.SerializeObject(messageBody);

            var response = await httpClient.GetResponse(uri, messageData);

            object model = endpoint switch
            {
                EndpointAdapter.send => JsonHelper.DeserializeResponseSmev<ResponseSentMessage>(response),
                EndpointAdapter.find => JsonHelper.DeserializeResponseSmev<QueryResult>(response),
                EndpointAdapter.get => JsonHelper.DeserializeResponseSmev<string>(response),
                _ => throw new InvalidEnumArgumentException(nameof(endpoint)),
            };

            return (Model)Convert.ChangeType(model, typeof(Model));
        }
    }
}
