#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring flex direction internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexDirectionInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="flexDirection">The flex direction value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FlexDirection flexDirection)
        {
            return flexDirection switch
            {
                FlexDirection.Row => "row",
                FlexDirection.RowReverse => "row-reverse",
                FlexDirection.Column => "column",
                FlexDirection.ColumnReverse => "column-reverse",
                _ => "row"
            };
        }

        #endregion
    }
}