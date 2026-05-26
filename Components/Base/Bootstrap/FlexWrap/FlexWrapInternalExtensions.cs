#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexWrapInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex wrap internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexWrapInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
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