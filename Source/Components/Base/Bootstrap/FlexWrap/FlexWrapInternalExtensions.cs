#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring flex wrap internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexWrapInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="flexWrap">The flex wrap value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FlexWrap flexWrap)
        {
            return flexWrap switch
            {
                FlexWrap.Wrap => "wrap",
                FlexWrap.NoWrap => "nowrap",
                FlexWrap.WrapReverse => "wrap-reverse",
                _ => "wrap"
            };
        }

        #endregion
    }
}