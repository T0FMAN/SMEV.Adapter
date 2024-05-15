using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using SMEV.Adapter.Types;

namespace SMEV.Adapter.Converters
{
    internal class MessageItemConverter : CustomCreationConverter<IMessage>
    {
        public override IMessage Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public IMessage Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("messageType")!;

            switch (type)
            {
                case "ResponseMessageType":
                    return new ResponseMessage();
                case "RequestMessageType":
                    return new RequestMessage();
            }

            throw new ApplicationException(string.Format("The message type {0} is not supported!", type));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            var target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}
