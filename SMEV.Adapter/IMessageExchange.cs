namespace SMEV.Adapter
{
    public interface IMessageExchange
    {
        Task<string> Send();
        Task<string> Get();
        Task<string> Find();
    }
}
