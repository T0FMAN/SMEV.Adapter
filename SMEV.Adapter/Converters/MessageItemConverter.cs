using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using SMEV.Adapter.Types;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.Find;

namespace SMEV.Adapter.Converters
{
    internal class MessageItemConverter : CustomCreationConverter<IMessage>
    {
        public override IMessage Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public static IMessage Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("messageType")!;

            var correctType = Enum.TryParse<MessageType>(type, out var messageType);

            if (!correctType)
                throw new ArgumentException($"Тип сообщения {type} отсутствует в перечислении");

            return messageType switch
            {
                MessageType.ErrorMessage => new ErrorMessage(),
                MessageType.StatusMessageType => new StatusMessage(),
                MessageType.QueryMessageType => new QueryMessage(),
                MessageType.ResponseMessageType => new ResponseMessage(),
                MessageType.RequestMessageType => new RequestMessage(),
                _ => throw new ApplicationException($"Тип сообщения {messageType} не поддерживается!"),
            };
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
