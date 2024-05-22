using System.Runtime.CompilerServices;

namespace SMEV.Adapter.Extensions
{
    internal static class ObjectExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ThrowIfNull<T>(
            this T? value,
            [CallerArgumentExpression(nameof(value))] string? parameterName = default) =>
            value ?? throw new ArgumentNullException(parameterName);
    }
}
