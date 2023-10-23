using Newtonsoft.Json;

namespace SMEV.Adapter.Helpers
{
    internal static class JsonHelper
    {
        internal static Model DeserializeResponseSmev<Model>(string data)
        {
            var model = JsonConvert.DeserializeObject<Model>(data);

            return model;
        }
    }
}
