#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring table section kind in BootstrapBuilder components.
    /// </summary>
    public static class TableSectionKindExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets tag for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="kind">The kind value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetTag(this TableSectionKind kind)
        {
            return kind switch
            {
                TableSectionKind.Header => "thead",
                TableSectionKind.Body => "tbody",
                TableSectionKind.Footer => "tfoot",
                _ => "tbody"
            };
        }

        #endregion
    }
}