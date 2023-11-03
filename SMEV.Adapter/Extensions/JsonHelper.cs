using Newtonsoft.Json;

namespace SMEV.Adapter.Extensions
{
    internal static class JsonExtensions
    {
        internal static Model DeserializeSmevResponse<Model>(this string data)
        {
            var model = JsonConvert.DeserializeObject<Model>(data);

            return model;
        }
    }
}
