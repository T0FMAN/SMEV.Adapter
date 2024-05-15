namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Электронная подпись
    /// </summary>
    public class XmldSigSignatureType
    {
        /// <summary>
        /// <para>Электронная подпись, по спецификации XMLDSig.</para>
        /// </summary>
        public object Any { get; set; } = default!;
    }
}
