namespace SMEV.Adapter.Exceptions
{
    [Serializable]
    public class InvalidArgumentSendedMessageException : Exception
    {
        public InvalidArgumentSendedMessageException() 
            : base(string.Format("Объект не соответсвует какой либо из модели отправляемого сообщения"))
        { 
        }

        public InvalidArgumentSendedMessageException(Type type) : base(string.Format("Invalid model type: {0}", type.Name)) 
        { 
        }
    }
}
