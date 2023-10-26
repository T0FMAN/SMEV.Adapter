namespace SMEV.Adapter.Helpers
{
    internal static class GuidHelper
    {
        internal static string GetUniqueId()
        {
            var guid = Guid.NewGuid();

            return guid.ToString();
        }
    }
}
