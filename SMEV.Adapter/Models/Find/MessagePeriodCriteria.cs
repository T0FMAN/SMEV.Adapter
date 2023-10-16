using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find
{
    public sealed class MessagePeriodCriteria
    {
        private DateTimeOffset _from;
        private DateTimeOffset _to;

        private static readonly string mask = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'+'K";

        [JsonProperty("from")]
        public string FromDate 
        { 
            get { return _from.ToString(mask); }
            set { _from = DateTime.Parse(value); } 
        }
        [JsonProperty("to")]
        public string ToDate
        {
            get { return _to.ToString(mask); }
            set { _to = DateTime.Parse(value); }
        }
    }
}
